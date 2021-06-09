﻿using System;
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
            publicProductList.Add(new Product { ID = 0, Name = "Stoel", Availability = true, Category = "Meubilair", Cost = 7, MaxHuurLengte = 14, Picture = "https://www.horecaoutlet.nl/wp-content/uploads/2018/04/DSC_0062.jpg" });
            publicProductList.Add(new Product { ID = 1, Name = "iPad", Availability = true, Category = "Elektronica", Cost = 27, MaxHuurLengte = 14, Picture = "https://cdn.pocket-lint.com/r/s/970x/assets/images/147515-tablets-review-ipad-mini-review-2019-image1-y5aisrcjw9.jpg" });
            publicProductList.Add(new Product { ID = 2, Name = "Tafel", Availability = true, Category = "Meubilair", Cost = 33, MaxHuurLengte = 14, Picture = "https://www.hetraaymakersantiek.nl/images/Antieke%20franse%20eetttafel%20,%20antieke%20eettafel%20,%20antieke%20franse%20tafels%20,%20antieke%20tafels%200380.T2%20(Large).JPG" });
            publicProductList.Add(new Product { ID = 3, Name = "Tshirt", Availability = true, Category = "Kleren", Cost = 1, MaxHuurLengte = 14, Picture = "https://www.large.nl/dw/image/v2/BBQV_PRD/on/demandware.static/-/Sites-master-emp/default/dw5b517c70/images/3/9/8/1/398120a.jpg?sfrm=png" });
            publicProductList.Add(new Product { ID = 4, Name = "Wasmachine", Availability = true, Category = "Witgoed", Cost = 5, MaxHuurLengte = 14, Picture = "https://images-ext-1.discordapp.net/external/75mep0IWl6pHqnsNnBoriKOo312Txf9TpeA8pnWnxgs/https/cdn.webshopapp.com/shops/296192/files/358278130/bauknecht-wasmachine-wa-care-14-di.jpg" });
            publicProductList.Add(new Product { ID = 5, Name = "Koptelefoon", Availability = true, Category = "Elektronica", Cost = 38, MaxHuurLengte = 14, Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ-shbyIirmnDGCPkQDw5wo7AhVGOvbkJYidw&usqp=CAU" });
            publicProductList.Add(new Product { ID = 6, Name = "Bed", Availability = true, Category = "Meubilair", Cost = 17, MaxHuurLengte = 14, Picture = "https://kringlooprijswijk.nl/wp-content/uploads/2020/12/97e3ccdd-f0e2-432f-9a3a-09bdc228c83d.jpeg" });
            publicProductList.Add(new Product { ID = 7, Name = "Mini Koelkast", Availability = true, Category = "Witgoed", Cost = 42, MaxHuurLengte = 14, Picture = "https://i.ebayimg.com/00/s/MTAyNFg3Njg=/z/m9sAAOSwnPtgkAfo/$_84.JPG" });
            publicProductList.Add(new Product { ID = 8, Name = "Trui", Availability = true, Category = "Kleren", Cost = 9, MaxHuurLengte = 14, Picture = "https://cdn.aktiefonline.nl/images/kleding/dames/12312/didi-trui-grijs-maat-s.jpg?w=360&h=250&q=70&m=1&c=00F" });
            publicProductList.Add(new Product { ID = 9, Name = "Broek", Availability = true, Category = "Kleren", Cost = 6, MaxHuurLengte = 14, Picture = "https://kringloop.nl/wp-content/uploads/2021/03/Broek-McGregor-Rood-Maat-3234-40114972-600x600.jpg" });
            publicProductList.Add(new Product { ID = 10, Name = "Schoenen", Availability = true, Category = "Kleren", Cost = 4, MaxHuurLengte = 14, Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRcRvxi7F1mHliohJ1a3WMpvwcZZU4u6nqeOw&usqp=CAU" });

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
            List<String> catogoryList = new List<String>() { "Elektronica", "Meubilair", "Kleren", "Witgoed", "Lege Categorie" };
            //TO DO ask productbeheer to return a list with unique catogories
            return catogoryList;
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

