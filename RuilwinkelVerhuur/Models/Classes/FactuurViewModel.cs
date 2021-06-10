using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Models.Classes
{
    public class FactuurViewModel
    {
        public IEnumerable<Factuur> FacturenViewModel { get; set; }

        public IEnumerable<ProductNaarFactuur> ProductNaarFactuurViewModel { get; set; }
    }
}
