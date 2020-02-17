namespace _03.CollectionOfProducts
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var products = new ProductCollection();
            products.Add(1, 100, "Title", "Gaco");
            products.Add(0, 100, "Title", "Gosho");
            var arr = products.FindProductByTitleAndPrice("Title", 100).ToArray();
        }
    }
}
