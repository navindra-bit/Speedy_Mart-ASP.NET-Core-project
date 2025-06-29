using Microsoft.AspNetCore.Mvc;

namespace Speedy_Groceries.Controllers
{
    public class CartController : Controller
    {
        [HttpGet]
        public IActionResult CartPage()
        {
            return View();
        }
        public IActionResult Orders()
        {
            return View();
        }
        public IActionResult Wishlist()
        {
            return View();
        }
    }
}
