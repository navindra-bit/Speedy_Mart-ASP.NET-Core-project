using Microsoft.AspNetCore.Mvc;
using Speedy_Groceries.Helpers;
using Speedy_Groceries.Models;
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
        public IActionResult set()
        {
            return View();
        }
        public IActionResult DeleteAccount()
        {
            return View();
        }
        public IActionResult RedirectToLogout()
        {
            return View();
        }

        public IActionResult AccountDelete(string userid)
        {
            var result = SqlAccountDeleteHelper.AccDelete(userid);

            if (result.Item1)
            {
              
                return View("RedirectToLogout");
            }

             
            ViewBag.Message = result.Item2;
            return View("DeleteAccount");
        }

    }
}
