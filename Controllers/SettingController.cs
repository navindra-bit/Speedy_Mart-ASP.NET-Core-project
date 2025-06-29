using Microsoft.AspNetCore.Mvc;

namespace Speedy_Groceries.Controllers
{
    public class SettingController : Controller
    {
        public IActionResult UserProfile()
        {
            return View();
        }
        public IActionResult Help()
        {
            return View();
        }
    }
}
