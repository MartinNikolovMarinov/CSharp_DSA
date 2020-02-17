namespace _03.CollectionOfProducts
{
    using System;
    public class Product : IComparable<Product>
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string Supplier { get; set; }

        public Product() 
        {
            this.Id = 0;
            this.Price = 0;
            this.Title = null;
            this.Supplier = null;
        }
        public Product(int id, decimal price, string title, string supplier) 
        {
            this.Id = id;
            this.Price = price;
            this.Title = title;
            this.Supplier = supplier;
        }

        public int CompareTo(Product other)
        {
            return this.Id.CompareTo(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (obj is Product)
            {
                return this.Id.Equals((obj as Product).Id);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}",  this.Title == null ? "No title" : this.Title);
        }
    }
}
