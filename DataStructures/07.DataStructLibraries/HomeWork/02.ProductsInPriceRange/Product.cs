﻿namespace _02.ProductsInPriceRange
{
    using System;

    public class Product : IComparable<Product>
    {
        public decimal Price { get; set; }
        public string Name { get; set; }

        public Product(string name, decimal price) 
        {
            this.Name = name;
            this.Price = price;
        }
        public Product(decimal price) 
        {
            this.Name = null;
            this.Price = price;
        }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}
