using Microsoft.AspNetCore.Mvc;
using Speedy_Groceries.Models;

namespace Speedy_Groceries.Controllers
{
    public class ProductsController : Controller
    {
        private static List<List<HomeProducts>>? electronics;
        private void InitializeElectronics()
        {
            if (electronics != null) return;

            electronics = new List<List<HomeProducts>>
            {
                 new List<HomeProducts> // Group 1
                {
                    new HomeProducts { Id = 1, Name = "Smartphone", Offer = "10% Off", Price = "₹19,999", Link = "Image/Smartphone.jpg" },
                    new HomeProducts { Id = 2, Name = "Bluetooth Speaker", Offer = "15% Off", Price = "₹2,499", Link = "Image/speaker.jpg" },
                    new HomeProducts { Id = 3, Name = "Laptop", Offer = "12% Off", Price = "₹49,999", Link = "Image/laptop.jpg" },
                    new HomeProducts { Id = 4, Name = "Wireless Earbuds", Offer = "20% Off", Price = "₹1,999", Link = "Image/earbuds.jpg" },
                    new HomeProducts { Id = 5, Name = "Smartwatch", Offer = "18% Off", Price = "₹3,499", Link = "Image/smartwatch.jpg" },
                    new HomeProducts { Id = 6, Name = "Tablet", Offer = "8% Off", Price = "₹14,999", Link = "Image/tablet.jpg" },
                },
                new List<HomeProducts> // Group 2
                {
                    new HomeProducts { Id = 7, Name = "Gaming Console", Offer = "5% Off", Price = "₹34,999", Link = "Image/console.jpg" },
                    new HomeProducts { Id = 8, Name = "LED Monitor", Offer = "11% Off", Price = "₹8,999", Link = "Image/monitor.jpg" },
                    new HomeProducts { Id = 9, Name = "DSLR Camera", Offer = "10% Off", Price = "₹39,999", Link = "Image/camera.jpg" },
                    new HomeProducts { Id = 10, Name = "VR Headset", Offer = "15% Off", Price = "₹12,499", Link = "Image/vr.jpg" },
                    new HomeProducts { Id = 11, Name = "Power Bank", Offer = "25% Off", Price = "₹799", Link = "Image/powerbank.jpg" },
                    new HomeProducts { Id = 12, Name = "Bluetooth Keyboard", Offer = "17% Off", Price = "₹1,299", Link = "Image/keyboard.jpg" },
                },
                new List<HomeProducts> // Group 3
                {
                    new HomeProducts { Id = 13, Name = "Webcam", Offer = "14% Off", Price = "₹1,499", Link = "Image/webcam.jpg" },
                    new HomeProducts { Id = 14, Name = "Headphones", Offer = "22% Off", Price = "₹5,999", Link = "Image/headphones.jpg" },
                    new HomeProducts { Id = 15, Name = "Smart TV", Offer = "9% Off", Price = "₹25,999", Link = "Image/smarttv.jpg" },
                    new HomeProducts { Id = 16, Name = "Portable Projector", Offer = "18% Off", Price = "₹9,499", Link = "Image/projector.jpg" },
                    new HomeProducts { Id = 17, Name = "WiFi Router", Offer = "13% Off", Price = "₹1,199", Link = "Image/router.jpg" },
                    new HomeProducts { Id = 18, Name = "External Hard Drive", Offer = "20% Off", Price = "₹4,499", Link = "Image/hdd.jpg" },
                },
                 new List<HomeProducts> // Group 4
                {
                    new HomeProducts { Id = 19, Name = "Surveillance Camera", Offer = "12% Off", Price = "₹2,299", Link = "Image/surveillance.jpg" },
                    new HomeProducts { Id = 20, Name = "USB Hub", Offer = "18% Off", Price = "₹499", Link = "Image/usbhub.jpg" },
                    new HomeProducts { Id = 21, Name = "Electric Kettle", Offer = "15% Off", Price = "₹1,299", Link = "Image/kettle.jpg" },
                    new HomeProducts { Id = 22, Name = "Photo Printer", Offer = "10% Off", Price = "₹6,499", Link = "Image/printer.jpg" },
                    new HomeProducts { Id = 23, Name = "Car Charger", Offer = "20% Off", Price = "₹399", Link = "Image/carcharger.jpg" },
                    new HomeProducts { Id = 24, Name = "Fitness Tracker", Offer = "13% Off", Price = "₹2,199", Link = "Image/tracker.jpg" },
                },
                new List<HomeProducts> // Group 5
                {
                    new HomeProducts { Id = 25, Name = "Streaming Stick", Offer = "17% Off", Price = "₹2,999", Link = "Image/streamstick.jpg" },
                    new HomeProducts { Id = 26, Name = "Electric Toothbrush", Offer = "9% Off", Price = "₹1,099", Link = "Image/toothbrush.jpg" },
                    new HomeProducts { Id = 27, Name = "Smart Plug", Offer = "11% Off", Price = "₹1,499", Link = "Image/smartplug.jpg" },
                    new HomeProducts { Id = 28, Name = "Digital Alarm Clock", Offer = "14% Off", Price = "₹849", Link = "Image/clock.jpg" },
                    new HomeProducts { Id = 29, Name = "Vacuum Cleaner", Offer = "16% Off", Price = "₹3,299", Link = "Image/vacuum.jpg" },
                    new HomeProducts { Id = 30, Name = "4K Action Camera", Offer = "19% Off", Price = "₹5,999", Link = "Image/actioncam.jpg" },
                },
                new List<HomeProducts> // Group 6
                {
                    new HomeProducts { Id = 31, Name = "Electric Shaver", Offer = "20% Off", Price = "₹2,199", Link = "Image/shaver.jpg" },
                    new HomeProducts { Id = 32, Name = "Smart Light Bulb", Offer = "18% Off", Price = "₹699", Link = "Image/smartbulb.jpg" },
                    new HomeProducts { Id = 33, Name = "HDMI Cable (3m)", Offer = "25% Off", Price = "₹349", Link = "Image/hdmi.jpg" },
                    new HomeProducts { Id = 34, Name = "Drone with Camera", Offer = "10% Off", Price = "₹7,499", Link = "Image/drone.jpg" },
                    new HomeProducts { Id = 35, Name = "Wireless Mouse", Offer = "22% Off", Price = "₹799", Link = "Image/mouse.jpg" },
                    new HomeProducts { Id = 36, Name = "Mini Tripod", Offer = "30% Off", Price = "₹399", Link = "Image/tripod.jpg" },
                }
            };
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Electronics()
        {
            InitializeElectronics();
            return View(electronics);
 
        }
        [HttpGet]
        public IActionResult ProductDetail(int id)
        {
            InitializeElectronics();
            var homeProduct = electronics!
             .SelectMany(group => group)
             .FirstOrDefault(p => p.Id == id);

            if (homeProduct == null)
                return NotFound();

            var product = new ProductsList
            {
                Id = homeProduct.Id,
                Name = homeProduct.Name,
                Offer = homeProduct.Offer,
                Price = homeProduct.Price,
                Link = homeProduct.Link
            };

            return View(product);
        }
    }
}
