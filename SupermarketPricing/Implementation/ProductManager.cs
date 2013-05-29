using System;

namespace SupermarketPricing.Implementation
{
    public class ProductManager
    {
        public Product Query(string productName)
        {
            switch (productName.ToLower())
            {
                case "can of beans": return new Product { Name = productName };
                case "bananas": return new Product { Name = productName };
                case "soda": return new Product { Name = productName };
                default: throw new ArgumentOutOfRangeException("productName",productName,"Unrecognized product");
            }
        }
    }
}