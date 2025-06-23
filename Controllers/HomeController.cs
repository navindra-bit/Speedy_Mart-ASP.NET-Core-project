using System;
using Microsoft.AspNetCore.Mvc;
using Speedy_Groceries.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Speedy_Groceries.Controllers
{
    public class HomeController : Controller
    {   
        List<HomeProducts>? products;
        [HttpGet]
        public IActionResult Index()
        {
            products = new List<HomeProducts>
            {
                new HomeProducts { Id = 1, Name = "Yoga Mat",  Offer = "20% Off", Price = "₹499", Link = "Image/yogamat.jpg" },
                new HomeProducts { Id = 2, Name = "Dumbbell Set", Offer = "15% Off", Price = "₹899", Link = "Image/dumbbells.jpg" },
                new HomeProducts { Id = 3, Name = "Protein Powder", Offer = "10% Off", Price = "₹1,299", Link = "Image/protein.jpg" },
                new HomeProducts { Id = 4, Name = "Digital Thermometer", Offer = "5% Off", Price = "₹199", Link = "Image/thermometer.jpg" },
                new HomeProducts { Id = 5, Name = "First Aid Kit", Offer = "18% Off", Price = "₹299", Link = "Image/firstaid.jpg" },
                new HomeProducts { Id = 6, Name = "Skipping Rope", Offer = "12% Off", Price = "₹149", Link = "Image/rope.jpg" },
                
            };

            ViewData["Ptitle"] = "Sports, Healthcare & more";
            ViewBag.Brand = products;

            TempData["Ptitle"] = "Beauty, Food & more";

            return View();
        }
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }
    }
}
