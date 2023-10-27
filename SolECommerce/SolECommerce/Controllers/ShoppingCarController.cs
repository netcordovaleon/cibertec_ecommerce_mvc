using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolECommerce.CustomExtensions;
using SolECommerce.DataAccess;
using SolECommerce.DataAccess.DBEntities;
using SolECommerce.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace SolECommerce.Controllers
{
    public class ShoppingCarController : Controller
    {
        private readonly IMapper _mapper;
         private readonly ShoppingContext _context;
        public ShoppingCarController
            (
                ShoppingContext context,
                IMapper mapper 
             )
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult ProductCatalog()
        {
            var productListDB = _context.Product.Where(c=>c.Status == true).ToList();
            var list = _mapper.Map<List<ProductCatalogViewModel>>(productListDB);
            return View(list);
        }

        public IActionResult ProductCategoryDetail(int id) {
            var productById = _context.Product.Where(c => c.Id == id && c.Status == true).SingleOrDefault();
            var productInView = _mapper.Map<ProductCatalogViewModel>(productById);
            return View(productInView);
        }

        [HttpPost]
        public JsonResult AddTemporalProduct(ProductTemporalViewModel param) {

            //CARGAMOS INFORMACION DEL PRODUCTO QUE INTENTAMOS AÑADIR AL CARRITO
            var productById = _context.Product.Where(c => c.Id == param.Id && c.Status == true).SingleOrDefault();
            param.ProductName = productById.ProductName;
            param.ProductPrice = productById.FinalPrice.Value;
            param.ImageURL = productById.ImageURL;

            //LISTA DE PRODUCTOS (TODOS) QUE ESTAN EN EL CARRITO
            List<ProductTemporalViewModel> temporalProducts = null; //= new List<ProductTemporalModel>();

            if (HttpContext.Session.GetList<ProductTemporalViewModel>("temporal") == null)
            {
                temporalProducts = new List<ProductTemporalViewModel>();
            }
            else 
            {
                temporalProducts = (List<ProductTemporalViewModel>)HttpContext.Session.GetList<ProductTemporalViewModel>("temporal");
            }
            temporalProducts.Add(param);
            HttpContext.Session.Set<List<ProductTemporalViewModel>>("temporal", temporalProducts);
            return new JsonResult(new { a = 1 }) ;
        }

        public IActionResult ConfirmShoppingCar()
        {
            var model = new ConfirmShoppingCarViewModel();
            model.TemporalProducts = (List<ProductTemporalViewModel>)HttpContext.Session.GetList<ProductTemporalViewModel>("temporal");
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveShoppingCard(ConfirmShoppingCarViewModel modelToSave) {
            modelToSave.TemporalProducts = (List<ProductTemporalViewModel>)HttpContext.Session.GetList<ProductTemporalViewModel>("temporal");

            //GRABAR CLIENTE
            var userRegistered = _context.Client.Add(new ClientEntity() {
                DocumentNumber = modelToSave.DocumentNumber,
                FirstName = modelToSave.FirstName,
                LastName = modelToSave.LastName,
                User = modelToSave.User,
                Password = modelToSave.Password,
                Status = true,
            });

            //GRABAR ORDEN
            var orderRegistered = _context.Order.Add(new OrderEntity() {
                CredictCartNumber = modelToSave.CredictCartNumber,
                CVV = modelToSave.CVV,
                ExpiredCartDate = modelToSave.ExpiredCartDate,
                Email = modelToSave.Email,
                OrderDate = DateTime.Now,
                Client = userRegistered.Entity,
                Status = true
            });

            //GRABAR PRODUCTOS
            foreach (var item in modelToSave.TemporalProducts)
            {
                _context.OrderDetail.Add(new OrderDetailEntity()
                {
                    Status = true,
                    FinalPrice = item.ProductPrice,
                    Order = orderRegistered.Entity,
                    Product = _context.Product.Where(c=>c.Id == item.Id).FirstOrDefault(),
                });
            }

            _context.SaveChanges();

            return RedirectToAction("MessageSuccessOrder");
        }


        public IActionResult MessageSuccessOrder()
        {
            return View();
        }

    }
}
