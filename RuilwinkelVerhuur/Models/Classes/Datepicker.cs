using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Models.Classes
{    
    //class that stores the picked date and loanlength when adding an item to the cart in detailpage
    public class Datepicker
    {
        public int LoanLength { get; set; }

        public  DateTime Date { get; set; }

        public int ID { get; set; }

    }
}
