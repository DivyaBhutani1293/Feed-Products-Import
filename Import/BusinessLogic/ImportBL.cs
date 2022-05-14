using Import.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Import
{
    public class ImportBL
    {
        public ProductDetailsJson getJsonData(string productFilePath)
        {
            using (StreamReader r = new StreamReader(productFilePath))
            {
                string json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<ProductDetailsJson>(json);
                return items;
            }
        }
    }
}
