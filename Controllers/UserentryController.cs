using Microsoft.AspNetCore.Mvc;
using Speedy_Groceries.Models;
using Microsoft.Data.SqlClient;
using Speedy_Groceries.Helpers;
namespace Speedy_Groceries.Controllers
{
    public class UserentryController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            UserInfo user = new UserInfo();
            return View(user);
        }
       
        public IActionResult Userdata(UserInfo userdata)
        {
            ViewBag.AlertType = "danger";
            if (userdata.password != userdata.Confirmpassword)
            {
                ViewBag.Message = "Oops! Passwords do not match. Please try again.";
                return View("Register", userdata);
            }
            
            var Reg = SqlSignupHelper.UserReg(userdata);
             ViewBag.Message = Reg.message;
                if (Reg.isvaild)
                {
                 ViewBag.AlertType = "success";
                 return View("Register", userdata);
                }
               
                return View("Register", userdata);
            }
           
        public  IActionResult UserLog(UserInfo userdata)
        {
            TempData["LoginAth"] = false;
            var isvaild = SqlLoginHelper.Logcheck(userdata);
            if (isvaild.Item1)
             {
                TempData["username"] = isvaild.Item2;
              TempData["LoginAth"] = true;
               return RedirectToAction("Index", "Home");
             }   
            ViewBag.Message = "Invalid email or password";
            return View("Login");
        }

        public IActionResult Logout()
        {
            TempData["LoginAth"] = false;
            return RedirectToAction("Index", "Home");
        }
    }
}
