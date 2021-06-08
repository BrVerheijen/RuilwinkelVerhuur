using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Models.Classes
{
    public class ProductComm
    {
        
        public static List<Product> retrieveList()
        {            
            List<Product> publicProductList = new List<Product>() { };
            publicProductList.Add(new Product { ID = 0, Name = "Stoel", Availability = true, Category = "Meubilair", Cost = 5, MaxHuurLengte = 14, Picture = "https://www.horecaoutlet.nl/wp-content/uploads/2018/04/DSC_0062.jpg" });
            publicProductList.Add(new Product { ID = 1, Name = "iPad", Availability = false, Category = "Elektronica", Cost = 50, MaxHuurLengte = 14, Picture = "https://www.apple.com/" });

            return publicProductList;
        }

        public static Product retrieveProduct(int searchid)
        {
            List<Product> productlist = ProductComm.retrieveList();
            Product returnproduct = new Product();
            foreach (var product in productlist)
            {
                if (product.ID == searchid)
                {
                    returnproduct = product;
                }
            }
            return returnproduct;
        }

        public static List<String> retrieveCatogories()
        {
            List<String> catogorieList = new List<String>() { "Elektronica", "Meubilair", "Kleren", "Curiosa", "Test" };
            //TO DO ask productbeheer to return a list with unique catogories
            return catogorieList;
        }

        //function that retrieves a list of products within a certain category
        public static List<Product> retrieveWithCategory(string category)
        {
            List<Product> productList = new List<Product>();
            foreach(var product in ProductComm.retrieveList())
            {
                if(product.Category == category)
                {
                    productList.Add(product);
                }
            }
            return productList;
        }
    }
}

