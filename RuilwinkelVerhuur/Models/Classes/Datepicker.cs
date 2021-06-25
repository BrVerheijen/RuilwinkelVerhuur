using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Models.Classes
{    
    public class Datepicker
    {
        public List<SelectListItem> LoanLength { get; set; }
        public  DateTime Date { get; set; }

        public int ID { get; set; }

    }
}
