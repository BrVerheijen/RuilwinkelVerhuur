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
        
        public List<int> dropdownList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
        //Sends productID to index page of details
        public ActionResult Index(int id)
        {            
            ViewBag.Message = id;
            ViewBag.Dropdown = dropdownList;

            return View();
        }

        //adds product to cart session if product is not in cart already
        public ActionResult AddToCart(int id)
        {
            
            if (SessionHelper.GetObjectFromJson<List<List<string>>>(HttpContext.Session, "cart") == null)
            {
                List<List<string>> cart = new List<List<string>>();
                List<string> itemInfo = new List<string>();
                itemInfo.Add(id.ToString());
                itemInfo.Add("30/06/2021");
                itemInfo.Add("1");
                cart.Add(itemInfo);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                bool isinlist = false;

                List<List<string>> cart = SessionHelper.GetObjectFromJson<List<List<string>>>(HttpContext.Session, "cart");
                
                foreach (List<string> i in cart)
                {
                    if (i[0] == id.ToString())
                    {
                        isinlist = true;
                    }
                }
                
                if (isinlist == false)
                {
                    List<string> itemInfo = new List<string>();
                    itemInfo.Add(id.ToString());
                    itemInfo.Add("30/06/2021");
                    itemInfo.Add("1");
                    cart.Add(itemInfo);
                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return View();
        }
    }
}
