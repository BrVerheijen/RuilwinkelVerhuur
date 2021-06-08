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
        
        public ActionResult Index(int id)
        {
            // var item = GetItemFromId(id);
            ViewBag.Message = id;
            return View();
        }

        public ActionResult AddToCart(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<int>>(HttpContext.Session, "cart") == null)
            {
                List<int> cart = new List<int>();
                cart.Add(id);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                bool isinlist = false;

                List<int> cart = SessionHelper.GetObjectFromJson<List<int>>(HttpContext.Session, "cart");
                
                foreach (var i in cart)
                {
                    if (i == id)
                    {
                        isinlist = true;
                    }
                }
                
                if (isinlist == false)
                {
                    cart.Add(id);
                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return View();
        }
    }
}
