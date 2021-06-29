using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Models.Classes
{
    public class ProductComm
    {
        static public List<Product> productList = new List<Product>();

        static HttpClient client = new HttpClient();

        public int ArticleID { get; set; }

        public int status { get; set; }

        public string naam { get; set; }

        //Retrieves a full list of products from productbeheer
        public static async Task<List<Product>> retrieveList()
        {            
            List<Product> publicProductList = new List<Product>() { };
            HttpResponseMessage response = await client.GetAsync("https://ruilwinkelvaalsproductbeheer.azurewebsites.net/api/Article/GetAvailableArticles");
            if (response.IsSuccessStatusCode)
            {
                List<Artikel> artikelList = await response.Content.ReadFromJsonAsync<List<Artikel>>();
                foreach(Artikel artikel in artikelList)
                {
                    publicProductList.Add(new Product { ID = artikel.articleID, Name = artikel.productname, Category = artikel.categoryname, 
                        Cost = artikel.points, Picture = artikel.image, Description = artikel.description });
                }
            }          
            
            return publicProductList;
        }              

        //returns product with specified id
        public static Product retrieveProduct(int searchid)
        {
            List<Product> productlist = ProductComm.retrieveList().Result;
            Product returnproduct = new Product();
            foreach (var product in productlist)
            {
                if (product.ID == searchid)
                {
                    returnproduct = product;
                    break;
                }
            }
            return returnproduct;
        }

        //retrieves unique catogories form productbeheer
        public static List<String> retrieveCatogories()
        {
            List<Product> productList = ProductComm.retrieveList().Result;
            List<String> catogoryList = new List<String>();
            
            foreach (Product product in productList)
            {
                if (!catogoryList.Contains(product.Category))
                {
                    catogoryList.Add(product.Category);
                }
            }
            //TO DO ask productbeheer to return a list with unique catogories
            return catogoryList;
        }

        //function that retrieves a list of products within a certain category
        public static List<Product> retrieveWithCategory(string category)
        {
            List<Product> productList = new List<Product>();
            foreach(var product in ProductComm.retrieveList().Result)
            {
                if(product.Category == category)
                {
                    productList.Add(product);
                }
            }
            return productList;
        }

        //function that asks productbeheer if the items in the cart are still available
        public static bool CheckCartAvailable(List<List<string>> cart)
        {
            //TODO ask products to return true or false
            List<Product> products = ProductComm.retrieveList().Result;
            int cartCounter = cart.Count();
            foreach(List<string> productInfo in cart)
            {
                foreach(Product product in products)
                {
                    if(Int32.Parse(productInfo[0]) == product.ID)
                    {
                        cartCounter--;
                        break;                        
                    }                    
                }
            }   
            if(cartCounter == 0)
            {
                return true;
            }
            else
            {
                return false;
            }                      
        }

        //function that tells productbeheer to set items in cart to unavailable
        public static async Task<Uri> SetProductUnavailable(int productID, string name)
        {   
            ProductComm obj = new() { ArticleID = productID, naam = name, status = 0 };
            

            var jsonString = JsonConvert.SerializeObject(obj);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PatchAsync("https://ruilwinkelvaalsproductbeheer.azurewebsites.net/api/Article/UpdateArticleStatus", content);

            response.EnsureSuccessStatusCode();
            
            return response.Headers.Location;           
        }

        public static async Task<Uri> SetProductAvailable(int productID)
        {

            ProductComm obj = new() { ArticleID = productID, status = 1 };
            

            var jsonString = JsonConvert.SerializeObject(obj);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PatchAsync("https://ruilwinkelvaalsproductbeheer.azurewebsites.net/api/Article/UpdateArticleStatus", content);

            response.EnsureSuccessStatusCode();

            
            return response.Headers.Location;
        }
    }
}

