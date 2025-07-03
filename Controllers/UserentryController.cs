using Microsoft.AspNetCore.Mvc;
using Speedy_Groceries.Models;
using Microsoft.Data.SqlClient;
using Speedy_Groceries.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
          //User Register
        public IActionResult Userdata(UserInfo userdata)
        {

            if (ModelState.IsValid )
            {
                if(!SqlSignupHelper.UserNameExists(userdata)  )
                {
                    ModelState.AddModelError("name", "*Username already exists.");
                    return View("Register", userdata);
                }
                if (!SqlSignupHelper.UserEmailExists(userdata))
                {
                    ModelState.AddModelError("email", "*Email already exists.");
                    return View("Register", userdata);
                }
                if (!SqlSignupHelper.UserPhoneNumberExists(userdata))
                {
                    ModelState.AddModelError("phoneNumber", "*PhoneNumber already exists.");
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
            return View("Register", userdata);
        }
           
      //  user Login
        public  IActionResult UserLog(LoginInfo loguserdata)
        {
            if (ModelState.IsValid)
            {
                if (SqlLoginHelper.UserEmailExists(loguserdata.Loginemail!))
                {
                    ModelState.AddModelError("Loginemail", "*Email does not exists.");
                    return View("Login", loguserdata);
                }
                 
                TempData["LoginAth"] = false;
                var isvaild = SqlLoginHelper.Logcheck(loguserdata);
                if(!isvaild.Item1 )
                {
                    ModelState.AddModelError("Loginpassword", "*Please enter a valid password.");
                        return View("Login", loguserdata);
                }
               
                    TempData["username"] = isvaild.Item2;
                    TempData["LoginAth"] = true;
                    TempData["Userid"] = isvaild.Item3;
                    return RedirectToAction("Index", "Home");                 
               
            }
            return View("Login");
        }

        public IActionResult Logout()
        {
            TempData["LoginAth"] = false;
            return RedirectToAction("Index", "Home");
        }
    }
}
