using System;
using System.Collections.Generic;
using System.Text;

namespace Import.Models
{
    public class ProductDetailsJson
    {
        public List<Product> products { get; set; }       
    }

    public class Product
    {
        public List<string> categories { get; set; }
        public string twitter { get; set; }
        public string title { get; set; }
    }
}
