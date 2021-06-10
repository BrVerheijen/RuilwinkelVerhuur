﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly DatabaseContext _context;
        public HomeController(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            if (SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user") == null)
            {
                User currentUser = AccountComm.retrieveUser();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "user", currentUser);
                ViewBag.user = currentUser;
            }
            else
            {
                User user = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
                ViewBag.user = user;
            }

            return View();
        }

        public IActionResult InventoryPage(string id)
        {
            ViewBag.category = id;
            return View();
        }
        
        public async Task<IActionResult> CheckoutPage()
        {            
            if (SessionHelper.GetObjectFromJson<List<int>>(HttpContext.Session, "cart") == null)
            {
                List<int> cart = new List<int>();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                ViewBag.cart = cart;
            }
            else
            {
                List<int> cart = SessionHelper.GetObjectFromJson<List<int>>(HttpContext.Session, "cart");
                ViewBag.cart = cart;
            }

            return View(await _context.Factuur.ToListAsync());
        }
        

        
        public  IActionResult Checkout(int id)
        {
            User user = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
            List<int> cart;
            Debug.WriteLine(id);
            if (SessionHelper.GetObjectFromJson<List<int>>(HttpContext.Session, "cart") == null)
            {
                cart = new List<int>();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                cart = SessionHelper.GetObjectFromJson<List<int>>(HttpContext.Session, "cart");
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }



            if (ProductComm.CheckCartAvailable(cart) && PuntenComm.SubstractPoints(user.WalletID, 0))
            {
                ProductComm.SetProductsUnavailable(cart);
                ViewBag.Succes = true;
                Factuur factuur = new Factuur { UserID = user.ID, Date = 8787 };
                if (ModelState.IsValid)
                {                    
                    _context.Add(factuur);
                     _context.SaveChangesAsync();

                    foreach (int productID in cart) 
                    {
                        ProductNaarFactuur productNaarFactuur = new ProductNaarFactuur { FactuurID = id, ProductID = productID, HuurLengte = 7, StartDate = "10/06/2021" };
                        _context.Add(productNaarFactuur);
                        _context.SaveChangesAsync();
                    }

                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                //pop message niet genoeg punten/producten niet meer beschikbaar
                ViewBag.Succes = false;
            }
            return View();
        }
        public async Task<IActionResult> OrderPage()
         {
            User user = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
            ViewBag.userID = user.ID;
            FactuurViewModel factuurViewModel = new FactuurViewModel();
            factuurViewModel.FacturenViewModel = await _context.Factuur.ToListAsync();
            factuurViewModel.ProductNaarFactuurViewModel = await _context.ProductNaarFactuur.ToListAsync();
            return View(factuurViewModel);
        }


        public IActionResult DeleteFromCart(int id)
        {

            if (SessionHelper.GetObjectFromJson<List<int>>(HttpContext.Session, "cart") == null)
            {
                List<int> cart = new List<int>();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);                
                
            }
            else
            {
                List<int> cart = SessionHelper.GetObjectFromJson<List<int>>(HttpContext.Session, "cart");
                cart.Remove(id);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);             

            }
            return View();
        }

        [HttpGet]
        public IActionResult DetailPage(int id)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
