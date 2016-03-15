    namespace OnlineMarket
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using Wintellect.PowerCollections;

    public class OnlineMarket
    {
        SortedDictionary<string, Product> productsByName = new SortedDictionary<string, Product>();
        Dictionary<string, SortedSet<Product>> productsByType = new Dictionary<string, SortedSet<Product>>();
        OrderedDictionary<double, SortedSet<Product>> productsByPrice = new OrderedDictionary<double, SortedSet<Product>>();

        public OnlineMarket() { }

        public void Add(Product product)
        {
            if (this.productsByName.ContainsKey(product.Name))
            {
                throw new ArgumentException(string.Format("Error: Product {0} already exists", product.Name));
            }

            // Add by name:
            this.productsByName.Add(product.Name, product);

            // Add by type:
            if (this.productsByType.ContainsKey(product.Type))
                this.productsByType[product.Type].Add(product);
            else
                this.productsByType.Add(product.Type, new SortedSet<Product>() { product });

            // Add by price:
            if (this.productsByPrice.ContainsKey(product.Price))
                this.productsByPrice[product.Price].Add(product);
            else
                this.productsByPrice.Add(product.Price, new SortedSet<Product>() { product });
        }

        public SortedSet<Product> FilterByType(string type) 
        {
            if (!this.productsByType.ContainsKey(type))
            {
                throw new ArgumentException(string.Format("Error: Product {0} does not exist", type));
            }

            return this.productsByType[type];
        }

        public List<Product> FilterByPriceRange(double min, double max) 
        {
            var setsOfProducts = this.productsByPrice.Range(min, true, max, true);
            var products = new List<Product>();
            if (setsOfProducts.Count == 0)
            {
                return new List<Product>();
            }

            foreach (var set in setsOfProducts)
            {
                foreach (var prduct in set.Value)
                {
                    products.Add(prduct);
                }
            }

            return products;
        }

        public List<Product> FilterByPriceFromMin(double min) 
        {
            var setsOfProducts = this.productsByPrice.RangeFrom(min, true);
            var products = new List<Product>();
            if (setsOfProducts.Count == 0)
            {
                return new List<Product>();
            }

            foreach (var set in setsOfProducts)
            {
                foreach (var prduct in set.Value)
                {
                    products.Add(prduct);
                }
            }

            return products;
        }

        public List<Product> FilterByPriceToMax(double max) 
        {
            var setsOfProducts = this.productsByPrice.RangeTo(max, true);
            var products = new List<Product>();
            if (setsOfProducts.Count == 0)
            {
                return new List<Product>();
            }
            
            foreach (var set in setsOfProducts)
            {
                foreach (var prduct in set.Value)
                {
                    products.Add(prduct);
                }
            }

            return products;
        }
    }
}
