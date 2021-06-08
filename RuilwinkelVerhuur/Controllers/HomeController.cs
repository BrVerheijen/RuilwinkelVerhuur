using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RuilwinkelVerhuur.Models;
using RuilwinkelVerhuur.Models.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CheckoutPage()
        {
            List<int> cart = SessionHelper.GetObjectFromJson<List<int>>(HttpContext.Session, "cart");

            ViewBag.cart = cart;

            return View();
        }
         public IActionResult OrderPage()
         {
             return View();
         }

        public IActionResult DeleteFromCart(int id)
        {
            List<int> cart = SessionHelper.GetObjectFromJson<List<int>>(HttpContext.Session, "cart");
            cart.Remove(id);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
