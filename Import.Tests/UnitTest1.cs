using Import;
using Import.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void getJsonDataTest()
        {
            ProductDetailsJson expected = new ProductDetailsJson();
            List<Product> list = new List<Product>();
            Product prod1 = new Product()
            {
                categories = new List<string> { "Customer Service", "Call Center" },
                title = "Freshdesk",
                twitter = "@freshdesk"
            };
            Product prod2 = new Product()
            {
                categories = new List<string> { "CRM","Sales Management" },
                title = "Zoho",
            };
            list.Add(prod1);
            list.Add(prod2);
            expected.products = list;

            ImportBL import = new ImportBL();
            ProductDetailsJson actual = import.getJsonData(@"D:\\GartnerTest\\Feed-Products\\Import\\Import\\Files\\feed-products\\softwareadvice.json");

            //checking the count of products
            Assert.AreEqual(expected.products.Count, actual.products.Count);

            //checking other details
            for(int i =0; i < expected.products.Count; i++)
            {
                for(int j=0; j < actual.products.Count; j++)
                {
                    if (i == j)
                    {
                        Assert.AreEqual(expected.products[i].categories, actual.products[i].categories);
                        Assert.AreEqual(expected.products[i].title, actual.products[i].title);
                        Assert.AreEqual(expected.products[i].twitter, actual.products[i].twitter);
                    }
                }
            }
        }
    }
}