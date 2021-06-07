using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Models.Classes
{
    public class Factuur
    {
        [Key]
        public int ID { get; set; }        

        public int UserID { get; set; }

        public long Date { get; set; }
    }
}
