using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Models.Classes
{
    //class to store the products
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }

        public int Cost { get; set; }

        public string Category { get; set; }
    }
}
