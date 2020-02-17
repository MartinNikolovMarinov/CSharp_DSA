namespace _03.CollectionOfProducts
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;
    using System.Collections.Generic;

    public class ProductCollection
    {
        Dictionary<int, Product> idProduct;
        OrderedMultiDictionary<string, Product> titleProduct;
        OrderedMultiDictionary<decimal, Product> priceProducts;
        OrderedMultiDictionary<string, Product> supplierProducts;
        OrderedMultiDictionary<Tuple<string, decimal>, Product> supplierPriceProducts;
        OrderedMultiDictionary<Tuple<string, decimal>, Product> titlePriceProducts;

        public int Count { get; set; }

        public ProductCollection() 
        {
            this.idProduct = new Dictionary<int, Product>();
            this.titleProduct = new OrderedMultiDictionary<string, Product>(false);
            this.priceProducts = new OrderedMultiDictionary<decimal, Product>(false);
            this.supplierProducts = new OrderedMultiDictionary<string, Product>(false);
            this.titlePriceProducts = new OrderedMultiDictionary<Tuple<string, decimal>, Product>(false);
            this.supplierPriceProducts = new OrderedMultiDictionary<Tuple<string, decimal>, Product>(false);
        }

        public void Add(Product product) 
        {
            this.Count++;
            
            // Id as key:
            if (this.idProduct.ContainsKey(product.Id))
            {
                this.Remove(product.Id);
            }

            // Add product by id
            if (!this.idProduct.ContainsKey(product.Id))
                this.idProduct.Add(product.Id, product);
            else 
                this.idProduct[product.Id] = product;

            // Add product by title
            if (!this.titleProduct.ContainsKey(product.Title))
                this.titleProduct.Add(product.Title, product);
            else
                this.titleProduct[product.Title].Add(product);

            // Add product by price range
            if (!this.priceProducts.ContainsKey(product.Price))
                this.priceProducts.Add(product.Price, product);
            else
                this.priceProducts[product.Price].Add(product);

            // Add product by title and price
            var titlePrice = new Tuple<string, decimal>(product.Title, product.Price);
            if (!this.titlePriceProducts.ContainsKey(titlePrice))
                this.titlePriceProducts.Add(titlePrice, product);
            else
                this.titlePriceProducts[titlePrice].Add(product);

            // add product by supplier
            if (!this.supplierProducts.ContainsKey(product.Supplier))
                this.supplierProducts.Add(product.Supplier, product);
            else
                this.supplierProducts[product.Supplier].Add(product);
                
            // Add product by supplier and price
            var supplierProduct = new Tuple<string, decimal>(product.Supplier, product.Price);
            if (!this.supplierPriceProducts.ContainsKey(supplierProduct))
                this.supplierPriceProducts.Add(supplierProduct, product);
            else
                this.supplierPriceProducts[supplierProduct].Add(product);
        }

        public void Add(int id, decimal price, string title, string supplier)
        {
            var newProduct = new Product(id, price, title, supplier);
            this.Add(newProduct);
        }

        public bool Remove(int id) 
        {
            if (!idProduct.ContainsKey(id))
            {
                return false;
            }

            this.Count--;
            var product = this.idProduct[id];
            var titlePrice = new Tuple<string, decimal>(product.Title, product.Price);
            var supplierProduct = new Tuple<string, decimal>(product.Supplier, product.Price);

            this.idProduct.Remove(id);
            this.titleProduct[product.Title].Remove(product);
            this.priceProducts[product.Price].Remove(product);
            this.titlePriceProducts[titlePrice].Remove(product);
            this.supplierProducts[product.Supplier].Remove(product);
            this.supplierPriceProducts[supplierProduct].Remove(product);
            return true;
        }

        public Product FindProductById(int id) 
        {
            if (!this.idProduct.ContainsKey(id))
            {
                return null;
            }
            
            return this.idProduct[id];
        }

        public IEnumerable<Product> FindProductsByTitle(string title)
        {
            if (!this.titleProduct.ContainsKey(title))
            {
                return null;
            }

            return this.titleProduct[title];
        }

        public IEnumerable<Product> FindProductsByPriceRange(decimal start, decimal end) 
        {
            var valuesInRange = this.priceProducts.Range(start, true, end, true).Values;
            return valuesInRange;
        }

        public IEnumerable<Product> FindProductByTitleAndPrice(string title, decimal price) 
        {
            var titlePrice = new Tuple<string, decimal>(title, price);
            if (!this.titlePriceProducts.ContainsKey(titlePrice))
            {
                return null;
            }
            
            return this.titlePriceProducts[titlePrice];
        }

        public IEnumerable<Product> FindProdcutByTitleAndPriceRange(string title, decimal start, decimal end) 
        {
            var procutsWithTheTitle = this.titleProduct[title];
            if (procutsWithTheTitle == null)
            {
                return null;   
            }

            var productsInRangeAndTitle = procutsWithTheTitle.Where(p => p.Price >= start && p.Price <= end);
            return productsInRangeAndTitle;
        }

        public IEnumerable<Product> FindProductBySupplierAndPrice(string supplier, decimal price)
        {
            var titlePrice = new Tuple<string, decimal>(supplier, price);
            if (!this.titlePriceProducts.ContainsKey(titlePrice))
            {
                return null;
            }

            return this.titlePriceProducts[titlePrice];
        }

        public IEnumerable<Product> FindProdcutBySupplierAndPriceRange(string supplier, decimal start, decimal end)
        {
            var procutsWithTheSupplier = this.supplierProducts[supplier];
            if (procutsWithTheSupplier == null)
            {
                return null;
            }

            var productsInRangeAndTitle = procutsWithTheSupplier.Where(p => p.Price >= start && p.Price <= end);
            return productsInRangeAndTitle;
        }
    }
}
