namespace _01.ProductsInPriceRange
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Wintellect.PowerCollections;

    class Program
    {
        static string GenStringFromNumer(int number)
        {
            StringBuilder sb = new StringBuilder();

            while (number > 0)
            {
                int remainder = number % 10;
                sb.Append((char)(remainder + 97));
                number /= 10;
            }

            return sb.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Start work on big data...");

            const int searchCount = 10000;
            const int productCount = 500000;
            OrderedBag<Product> productBag = new OrderedBag<Product>();
            Random rnd = new Random();

            for (int i = 0; i < productCount; i++)
            {
                productBag.Add(new Product(GenStringFromNumer(rnd.Next(i, i + 200)),
                    (decimal)rnd.Next(rnd.Next(20000))));
            }

            for (int i = 0; i < searchCount; i++)
            {
                var from = new Product(i);
                var to = new Product(i + 200);
                var priceRange = productBag.Range(from, true, to, true);
            }

            Console.WriteLine("Done.");
        }
    }
}
