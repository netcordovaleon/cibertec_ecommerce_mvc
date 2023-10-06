using Microsoft.AspNetCore.Mvc;

namespace SolECommerce.Controllers
{
    public class ShoppingCarController : Controller
    {
        public IActionResult ProductCatalog()
        {
            return View();
        }

        public IActionResult ProductCategoryDetail(int id) {
            return View();
        }


        public IActionResult ConfirmShoppingCar()
        {
            return View();
        }

    }
}
