using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Models.Classes
{
    //database class to store the orderinfo of a single product
    public class ProductNaarFactuur
    {
        [Key]
        public int ID { get; set; }      
                
        public int ProductID { get; set; }
        
        public int FactuurID { get; set; }        
        public string StartDate { get; set; }

        public int HuurLengte { get; set; }

        public int Cost { get; set; }

        public string ProductPicture { get; set; }

        public string ProductName { get; set; }
    }
}
