using Microsoft.AspNetCore.Mvc;
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

        //Set user when you visit the homepage and the session is empty
        public IActionResult Index()
        {
            if (SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user") == null)
            {
                //TODO send user back to login
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

        //send to inventorypage with categoryID
        public IActionResult InventoryPage(string id)
        {
            ViewBag.category = id;
            return View();
        }
        
        //sends to checkoutpage and gets the cart items form the session
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

        //TODO andere manier om factuur id op te halen
        //Function that checksout the session cart and makes new database entries
        public async Task<IActionResult> Checkout(int punten)
        {
            User user = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
            List<int> cart;            
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



            if (ProductComm.CheckCartAvailable(cart) && PuntenComm.SubstractPoints(user.WalletID, punten))
            {
                ProductComm.SetProductsUnavailable(cart);
                ViewBag.Succes = true;
                Factuur factuur = new Factuur { UserID = user.ID, Date = 8787 };
                if (ModelState.IsValid)
                {                    
                    _context.Add(factuur);
                     await _context.SaveChangesAsync();

                    List<Factuur> list = await _context.Factuur.ToListAsync();
                    int lastID = list[list.Count - 1].ID;
                    foreach (int productID in cart)
                    {
                        foreach (Product product in ProductComm.retrieveList())
                        {
                            if (productID == product.ID)
                            {
                                ProductNaarFactuur productNaarFactuur = new ProductNaarFactuur { FactuurID = lastID, ProductID = productID, HuurLengte = 7, StartDate = "10/06/2021", Cost = product.Cost };
                                _context.Add(productNaarFactuur);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }                    

                    Emailer.FactuurGenerator(cart, factuur, user);

                    cart = new List<int>();
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                    
                }
            }
            else
            {
                //pop message niet genoeg punten/producten niet meer beschikbaar
                ViewBag.Succes = false;
            }
            return RedirectToAction("OrderPage", "Home");
            
        }

        public async Task<IActionResult> RefundFactuur(int id)
        {
            User user = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user"); // get user form the session
            Factuur factuur = await _context.Factuur.FindAsync(id); // find factuur with id parameter
            List<ProductNaarFactuur> productNaarFactuurTable = await _context.ProductNaarFactuur.ToListAsync(); // get productnaarfactuurtable
            List<Product> products = ProductComm.retrieveList(); // get the list of all products
            List<int> productIDs = new List<int>();
            int costs = 0;
            foreach (ProductNaarFactuur productNaarFactuur in productNaarFactuurTable)
            {
                if(productNaarFactuur.FactuurID == factuur.ID)
                {
                    productIDs.Add(productNaarFactuur.ProductID);
                    costs += productNaarFactuur.Cost;
                    _context.ProductNaarFactuur.Remove(productNaarFactuur);
                    await _context.SaveChangesAsync();
                }
            }
            
            PuntenComm.RefundProduct(costs, user.WalletID);
            ProductComm.SetProductsAvailable(productIDs);
            _context.Factuur.Remove(factuur);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RefundProduct(int id)
        {
            User user = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user"); // get user form the session
            List<Product> products = ProductComm.retrieveList(); // get the list of all products
            ProductNaarFactuur productNaarFactuur = await _context.ProductNaarFactuur.FindAsync(id); // find the productnaarfactuur with id parameter
            Product refundedProduct = new Product();
            Factuur factuur = await _context.Factuur.FindAsync(productNaarFactuur.FactuurID); // find the factuur that contains our productnaarfactuur
            List<int> productID = new List<int>();
            List<ProductNaarFactuur> productNaarFactuurTable = await _context.ProductNaarFactuur.ToListAsync(); // get productnaarfactuurtable
            List<ProductNaarFactuur> productNaarFactuurInFactuur = new List<ProductNaarFactuur>();        

            
            PuntenComm.RefundProduct(refundedProduct.Cost, user.WalletID);
            ProductComm.SetProductsAvailable(productID);
            _context.ProductNaarFactuur.Remove(productNaarFactuur);
            await _context.SaveChangesAsync();
            productNaarFactuurTable = await _context.ProductNaarFactuur.ToListAsync();

            foreach (ProductNaarFactuur product in productNaarFactuurTable)
            {
                if (product.FactuurID == factuur.ID)
                {
                    productID.Add(product.ProductID);
                    productNaarFactuurInFactuur.Add(product);
                }
            }

            if(productNaarFactuurInFactuur.Count == 0)
            {
                _context.Factuur.Remove(factuur);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        //sends to orderpage and gives acces to both factuur and productnaarfactuur models within the factuurviewmodel
        public async Task<IActionResult> OrderPage()
         {
            User user = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
            ViewBag.userID = user.ID;
            FactuurViewModel factuurViewModel = new FactuurViewModel();
            factuurViewModel.FacturenViewModel = await _context.Factuur.ToListAsync();
            factuurViewModel.ProductNaarFactuurViewModel = await _context.ProductNaarFactuur.ToListAsync();
            return View(factuurViewModel);
        }

        //removes item from session cart
        public IActionResult DeleteFromCart(int id)
        {            
            List<int> cart = SessionHelper.GetObjectFromJson<List<int>>(HttpContext.Session, "cart");
            cart.Remove(id);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);


            return RedirectToAction("CheckoutPage", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
