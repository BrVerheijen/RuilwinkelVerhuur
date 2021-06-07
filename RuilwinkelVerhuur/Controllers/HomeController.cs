using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RuilwinkelVerhuur.Data;
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
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CheckoutPage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckoutPage(ProductNaarFactuur order)
        {
            _db.ProductNaarFactuurTable.Add(order);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
         public IActionResult OrderPage()
         {
            IEnumerable<Factuur> factuurList = _db.FactuurTable;
            IEnumerable<ProductNaarFactuur> orderList = _db.ProductNaarFactuurTable;
             return View(orderList);
         }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
