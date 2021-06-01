using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RuilwinkelVerhuur.Models.Classes;

namespace RuilwinkelVerhuur.Controllers
{
    public class DetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Product product)
        {
            int ProductID = product.ID;
            string Name = product.Name;
            bool Availability = product.Availability;
            string Category = product.Category;
            string Picture = product.Picture;
            int Cost = product.Cost;
            int MaxHuurLengte = product.MaxHuurLengte;


            return View();
        }
    }
}
