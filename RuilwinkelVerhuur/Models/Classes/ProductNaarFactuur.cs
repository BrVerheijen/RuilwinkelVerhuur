using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Models.Classes
{
    public class ProductNaarFactuur
    {
        public int ID;

        public int ProductID;

        public int FactuurID;

        public string StartDate;

        public int HuurLengte;
    }
}
