using Import.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.NamingConventionBinder;
using System.IO;
using System.Threading.Tasks;
using YamlDotNet.Serialization.NamingConventions;

namespace Import
{
    class Program
    {
        static void Main(string[] args)
        {
            var productName1 = new Argument<string>("name", "Product Name");
            var productFilePath1 = new Argument<string>("path", "Product File Path");

            var cmd = new RootCommand();
            cmd.AddArgument(productName1);
            cmd.AddArgument(productFilePath1);

            //cmd.Handler = CommandHandler.Create<string, string>(ShowOutput);
            cmd.Handler = CommandHandler.Create<string, string>
            ((productName, productFilePath) =>
            {
                ShowOutput(productName, productFilePath);
            });


            //return cmd.Invoke(args);

        }

        private static void ShowOutput(string productName, string productFilePath)
        {
            string fileType = productFilePath.Substring(productFilePath.Length - 4);
            if (fileType == "json")
            {
                ImportBL import = new ImportBL();
                ProductDetailsJson items = import.getJsonData(productFilePath);
                if (items != null && items.products != null)
                {
                    foreach (var item in items.products)
                    {
                       string categories = String.Join(",", item.categories); //converting list of categories to comma separated string
                       string name = '"' + item.title + '"'; // included double quotes in name
                       Console.WriteLine($"importing: Name: {name}; Categories: {categories}; Twitter: {item.twitter}");
                    }
                }
            }
            else if (fileType == "yaml")
            {
                string yaml = File.ReadAllText(productFilePath);
                var deserializer = new YamlDotNet.Serialization.DeserializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();
                string[] arr = yaml.Split("-");

                foreach (var str in arr)
                {
                    if (str != "" && str != "\n")
                    {
                        var item = deserializer.Deserialize<ProductDetailsYaml>(str);
                        string twitter = '@' + item.twitter; // prepend @ in twitter
                        string name = '"' + item.name + '"'; // included double quotes in name
                        Console.WriteLine($"importing: Name: {name}; Categories: {item.tags}; Twitter: {twitter}");
                    }
                }
            }
            else
            {
                throw new NotImplementedException();
            }
            Console.ReadLine();
        }

    }
}
