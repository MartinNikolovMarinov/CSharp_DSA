namespace OnlineMarket
{
    using System;
using System.Collections.Generic;
using System.Linq;

    public static class CommandController
    {
        private static readonly int MAX_PRODUCT = 10;

        public static bool ExecuteCommand(string commandLine, OnlineMarket market) 
        {
            bool end = false;
            string[] commands = commandLine.Split();
            
            if (commands[0] == "add")
            {
                Product product = new Product(commands[1], double.Parse(commands[2]), commands[3]);
                
                try
                {
                    market.Add(product);
                    Console.Write("Ok: Product {0} added successfully", product.Name);
                }
                catch (ArgumentException ex)
                {
                    Console.Write(ex.Message);
                }
            }
            else if (commands[0] == "filter")
            {
                if (commands[2] == "type")
                {
                    try
                    {
                        var topProducts = market.FilterByType(commands[3]);
                        PrintProducts(topProducts, MAX_PRODUCT);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.Write(ex.Message);
                    }
                }
                else if (commands[2] == "price" && commands.Length == 7)
                {
                    double min = double.Parse(commands[4]);
                    double max = double.Parse(commands[6]);
                    List<Product> topProducts = market.FilterByPriceRange(min, max);
                    PrintProducts(topProducts, MAX_PRODUCT);
                }
                else if (commands[2] == "price" && commands[3] == "to")
                {
                    double max = double.Parse(commands[4]);
                    List<Product> topProducts = market.FilterByPriceToMax(max);
                    PrintProducts(topProducts, MAX_PRODUCT);
                }
                else 
                {
                    double min = double.Parse(commands[4]);
                    List<Product> allProducts = market.FilterByPriceFromMin(min);
                    PrintProducts(allProducts, allProducts.Count);
                }
            }
            else if (commands[0] == "end")
            {
                end = true;
            }

            Console.WriteLine();
            return end;
        }

        private static void PrintProducts(ICollection<Product> products, int max) 
        {
            int count = 1;
            Console.Write("Ok: ");
            foreach (var p in products)
            {
                if (count == products.Count || count == max)
                    Console.Write("{0}", p.ToString());
                else
                    Console.Write("{0}, ", p.ToString());

                count++;
            }
        }
    }
}
