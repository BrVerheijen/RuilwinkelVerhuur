using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Models.Classes
{
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }         

        public int Cost { get; set; }

        public string Category { get; set; }
    }
}
