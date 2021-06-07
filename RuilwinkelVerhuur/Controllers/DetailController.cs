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
            //ViewBag.Message = id;
            return View(id);
        }
    }
}
