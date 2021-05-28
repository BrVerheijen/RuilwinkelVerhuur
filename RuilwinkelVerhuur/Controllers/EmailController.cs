using Microsoft.AspNetCore.Mvc;
using RuilwinkelVerhuur.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Controllers
{
    public class EmailController : Controller
    {
        public ActionResult Index()
        {
            Emailer.MailGenerateTest();
            return View();
        }
    }
}
