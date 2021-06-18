using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Models.Classes
{
    public class ProductNaarFactuur
    {
        [Key]
        public int ID { get; set; }      
                
        public int ProductID { get; set; }
        
        public int FactuurID { get; set; }        
        public string StartDate { get; set; }

        public int HuurLengte { get; set; }

        //public int Cost { get; set; }
    }
}
