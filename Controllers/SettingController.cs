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
        public IActionResult Set()
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








        public IActionResult EditProfile()
        {
            var user = new UserInfo
            {
                name = "John Doe",
                email = "john@example.com",
                phoneNumber = "9876543210"
            };

            ViewBag.EditMode = false; // Initially read-only
            return View(user);
        }

        [HttpPost]
        public IActionResult EditProfile(UserInfo user)
        {
            ViewBag.EditMode = true; // Allow editing after button click
            return View(user);
        }

        [HttpPost]
        public IActionResult SaveProfile(UserInfo user)
        {
            // Save logic here
            ViewBag.EditMode = false;
            return View("EditProfile", user);
        }













    }
}
