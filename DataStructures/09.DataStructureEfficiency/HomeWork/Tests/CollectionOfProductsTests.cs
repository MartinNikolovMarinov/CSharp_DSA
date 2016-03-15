namespace Tests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using _03.CollectionOfProducts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CollectionOfProductsTests
    {
        [TestMethod]
        public void FindProductsByTitle()
        {
            var products = new ProductCollection();
            var result = products.FindProductsByTitle("Title");
            
            Assert.AreEqual(null, result);
            products.Add(1, 200, "Title", "Gaco");
            products.Add(0, 100, "Title", "Gosho");
            var arr = products.FindProductsByTitle("Title").ToArray();

            Assert.AreEqual(0, arr[0].Id);
            Assert.AreEqual(100m, arr[0].Price);
            Assert.AreEqual("Title", arr[0].Title);
            Assert.AreEqual("Gosho", arr[0].Supplier);
            Assert.AreEqual(1, arr[1].Id);
            Assert.AreEqual(200m, arr[1].Price);
            Assert.AreEqual("Title", arr[1].Title);
            Assert.AreEqual("Gaco", arr[1].Supplier);

            products.Add(0, 1000, "Title", "Pesho");
            arr = products.FindProductsByTitle("Title").ToArray();

            Assert.AreEqual(0, arr[0].Id);
            Assert.AreEqual(1000m, arr[0].Price);
            Assert.AreEqual("Title", arr[0].Title);
            Assert.AreEqual("Pesho", arr[0].Supplier);
            Assert.AreEqual(1, arr[1].Id);
            Assert.AreEqual(200m, arr[1].Price);
            Assert.AreEqual("Title", arr[1].Title);
            Assert.AreEqual("Gaco", arr[1].Supplier);
        }

        [TestMethod]
        public void FindProductsById()
        {
            var products = new ProductCollection();
            products.Add(1, 200, "Title", "Gaco");
            products.Add(0, 100, "Title", "Gosho");
            var result = products.FindProductById(1);

            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(200m, result.Price);
            Assert.AreEqual("Title", result.Title);
            Assert.AreEqual("Gaco", result.Supplier);

            products.Add(0, 1000, "Title", "Pesho");
            result = products.FindProductById(1);

            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(200m, result.Price);
            Assert.AreEqual("Title", result.Title);
            Assert.AreEqual("Gaco", result.Supplier);
        }

        [TestMethod]
        public void FindProductByTitleAndPriceTest() 
        {
            var products = new ProductCollection();
            products.Add(1, 100, "Title", "Gaco");
            products.Add(0, 100, "Title", "Gosho");
            var arr = products.FindProductByTitleAndPrice("Title", 100).ToArray();
            
            Assert.AreEqual(0, arr[0].Id);
            Assert.AreEqual(100m, arr[0].Price);
            Assert.AreEqual("Title", arr[0].Title);
            Assert.AreEqual("Gosho", arr[0].Supplier);

            Assert.AreEqual(1, arr[1].Id);
            Assert.AreEqual(100m, arr[1].Price);
            Assert.AreEqual("Title", arr[1].Title);
            Assert.AreEqual("Gaco", arr[1].Supplier);

        }
    }
}
