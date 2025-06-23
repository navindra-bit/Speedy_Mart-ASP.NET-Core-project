using Microsoft.AspNetCore.Mvc;

namespace Speedy_Groceries.Controllers
{
    public class CartController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
