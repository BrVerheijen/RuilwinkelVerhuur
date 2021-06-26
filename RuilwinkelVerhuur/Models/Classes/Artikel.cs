using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Models.Classes
{
    public class Artikel
    {
        public string productname { get; set; }

        public string description { get; set; }

        public string categoryname { get; set; }

        public int articleID { get; set; }

        public int points { get; set; }

        public string image { get; set; }
    }
}
