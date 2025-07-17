using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Speedy_Groceries.Helpers;
using Speedy_Groceries.Models;
namespace Speedy_Groceries.Controllers
{
    public class UserentryController(AppDataBaseContext dbContext) : Controller
    {
        private readonly AppDataBaseContext _DbContext = dbContext; //primary constructor


        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            UserInfo user = new();
            return View(user);
        }
        // ✅ User Registration
        public IActionResult Userdata(UserInfo userdata)
        {

            if (ModelState.IsValid)
            {

                var userexits = _DbContext.UserInfo.Where(x => x.name == userdata.name || x.email == userdata.email || x.phoneNumber == userdata.phoneNumber).ToList();
                foreach (var user in userexits)
                { 
                    if (user.name == userdata.name)
                    {
                        ModelState.AddModelError("name", "*Username already exists.");
                       
                    }
                    if (user.email == userdata.email)
                    {
                        ModelState.AddModelError("email", "*Email already exists.");
                         
                    }
                    if (user.phoneNumber == userdata.phoneNumber)
                    {
                        ModelState.AddModelError("phoneNumber", "*PhoneNumber already exists.");
                      
                    }
                    
                }
                if(!ModelState.IsValid)
                {
                    return View("Register", userdata);
                }
                _DbContext.UserInfo.Add(userdata);
                _DbContext.SaveChanges();
                
               

            }
            return View("Register", userdata);
        }

        // ✅ User Login
        public IActionResult UserLog(LoginInfo loguserdata)
        {
            if (ModelState.IsValid)
            {
                TempData["LoginAth"] = false;
               var data = _DbContext.UserInfo.FirstOrDefault(x => x.email == loguserdata.Loginemail);
               if(data == null)
                {
                    ModelState.AddModelError("Loginemail", "*Enter a vaild Email");
                    
                }
                if( data != null && data.password == loguserdata.Loginpassword) {
            
                    TempData["username"] = data.name;
                    TempData["LoginAth"] = true;
                    TempData["Userid"] = data.uid;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("Login");
        }

        public IActionResult Logout()
        {
            TempData["LoginAth"] = false;
            return RedirectToAction("Index", "Home");
        }




        [Route("Userentry/delete/{id}")]
        public IActionResult UserDelete([FromRoute]int id)
        {
            var data = _DbContext.UserInfo.FirstOrDefault(x => x.uid == id);
            if(data is not null)
            {
                _DbContext.UserInfo.Remove(data);
                _DbContext.SaveChanges();
            }
            return View("Register");
        }
        [Route("Userentry/Update/{id}")]
        public IActionResult UserUpdate([FromRoute] int id,[FromQuery]string name)
        {
            var data = _DbContext.UserInfo.FirstOrDefault(x => x.uid == id);
            if (data is not null)
            {
                data.name = name;
                _DbContext.SaveChanges();
            }
            return View("Register",data);
        }
          
          
        [Route("Userentry/getuser/{id}")]
        public IActionResult Getuser([FromRoute] int id)
        {
            var data = _DbContext.UserInfo.FirstOrDefault(x => x.uid == id);
            if (data is not null)
            {
                return View("Register",data);
            }
            
            return View("Register");
        }







        //Sample Controller Actions 

        [Route("WebsiteDir")]
        public IActionResult WebsiteDir()
        {
            return Redirect("http://jsdevbrains.com/");
        }


        [Route("OtherController")]
        public IActionResult OtherController()
        {
            return RedirectToRoute(new { Controller = "Products", Action = "Electronics" });
        }


        [Route("HtmlContent")]
        public IActionResult HtmlContent()
        {
            return Content("<h1>Hello How are you ? </h1> ", "text/html");
        }


        [Route("FileConcept")]
        public IActionResult FileConcept()
        {
           return PhysicalFile("C:\\Users\\NAVINDRA\\Desktop\\C Sharp Learing\\csharp_tutorial.pdf" , "application/pdf" , "csharp.pdf" );
        }


        [Route("virtualfiles")]
        public IActionResult Virtualfiles()
        {
            return new VirtualFileResult("~/AllFile/csharp_tutorial.pdf", "application/pdf");
        }


        [Route("Byteconvertion")]
        public IActionResult Byteconvertion()
        {
            byte[] bytesconvert = System.IO.File.ReadAllBytes("C:\\Users\\NAVINDRA\\Desktop\\C Sharp Learing\\csharp_tutorial.pdf");
            return File(bytesconvert, "application/pdf", "DemocsharpByteconvert.pdf");
        }
    }
}











//public IActionResult Userdata(UserInfo userdata)
//{

//    if (ModelState.IsValid)
//    {
//        if (!SqlSignupHelper.UserNameExists(userdata))
//        {
//            ModelState.AddModelError("name", "*Username already exists.");
//            return View("Register", userdata);
//        }
//        if (!SqlSignupHelper.UserEmailExists(userdata))
//        {
//            ModelState.AddModelError("email", "*Email already exists.");
//            return View("Register", userdata);
//        }
//        if (!SqlSignupHelper.UserPhoneNumberExists(userdata))
//        {
//            ModelState.AddModelError("phoneNumber", "*PhoneNumber already exists.");
//            return View("Register", userdata);
//        }

//        var Reg = SqlSignupHelper.UserReg(userdata);
//        ViewBag.Message = Reg.message;
//        if (Reg.isvaild)
//        {
//            ViewBag.AlertType = "success";
//            return View("Register", userdata);
//        }
//        return View("Register", userdata);
//        _DbContext.UserInfo.Add(userdata);
//        _DbContext.SaveChanges();

//    }
//    return View("Register", userdata);
//}



//public IActionResult UserLog(LoginInfo loguserdata)
//{
//    if (ModelState.IsValid)
//    {
//        if (SqlLoginHelper.UserEmailExists(loguserdata.Loginemail!))
//        {
//            ModelState.AddModelError("Loginemail", "*Email does not exists.");
//            return View("Login", loguserdata);
//        }

//        TempData["LoginAth"] = false;
//        var isvaild = SqlLoginHelper.Logcheck(loguserdata);
//        if (!isvaild.Item1)
//        {
//            ModelState.AddModelError("Loginpassword", "*Please enter a valid password.");
//            return View("Login", loguserdata);
//        }

//        TempData["username"] = isvaild.Item2;
//        TempData["LoginAth"] = true;
//        TempData["Userid"] = isvaild.Item3;
//        return RedirectToAction("Index", "Home");

//    }
//     return View("Login");