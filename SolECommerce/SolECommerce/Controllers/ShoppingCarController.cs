using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SolECommerce.DataAccess;
using SolECommerce.Models;
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
            var list = _mapper.Map<List<ProductCatalogModel>>(productListDB);
            return View(list);
        }

        public IActionResult ProductCategoryDetail(int id) {
            var productById = _context.Product.Where(c => c.Id == id && c.Status == true).SingleOrDefault();
            var productInView = _mapper.Map<ProductCatalogModel>(productById);
            return View(productInView);
        }


        public IActionResult ConfirmShoppingCar()
        {
            return View();
        }

    }
}
