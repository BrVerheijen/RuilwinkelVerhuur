using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RuilwinkelVerhuur.Models.Classes;

namespace RuilwinkelVerhuur.Views.Home
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            Product product = new Product(); 
            product.ID = 1;
            product.Name = "Stoel";
            product.Picture = "https://www.horecaoutlet.nl/wp-content/uploads/2018/04/DSC_0062.jpg";
            product.MaxHuurLengte = 14;
            product.Availability = true;
            product.Cost = 69;
            product.Category = "Meubilair";
        }

            
                

            

        
    }
}
