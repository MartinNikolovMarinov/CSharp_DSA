namespace OnlineMarket
{
    using System;
    
    public class Product : IComparable<Product>
    {
        public Product(string name = null, double price = 0.0d, string type = null) 
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }

        public int CompareTo(Product other)
        {
            int priceDelta = this.Price.CompareTo(other.Price);
            int nameDelta = this.Name.CompareTo(other.Name);
            int typeDelta = this.Type.CompareTo(other.Type);

            if (priceDelta != 0)
                return priceDelta;
            else if (nameDelta != 0)
                return nameDelta;
            else
                return typeDelta;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price);
        }
    }
}
