using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RuilwinkelVerhuur.Models.Classes;
using System.Collections.Generic;

namespace UnitTestVerhuur
{
    [TestClass]
    public class ProductCommTest
    {
        [TestMethod]
        public void CategoryTest()
        {
            string category = ProductComm.retrieveCatogories()[0];

            Assert.IsNotNull(ProductComm.retrieveWithCategory(category));


        }
        [TestMethod]
        public void RetrieveProductTest()
        {
            Product testproduct = ProductComm.retrieveProduct(1);
            List<Product> products = ProductComm.retrieveList().Result;
            foreach(Product product in products)
            {
                if (product.ID == 1)
                {
                    Assert.AreEqual(testproduct.ID, product.ID);
                }
                
            }
            
        }
       
    }
   
}
