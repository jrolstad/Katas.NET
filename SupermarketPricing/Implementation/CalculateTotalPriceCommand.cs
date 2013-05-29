using System;

namespace SupermarketPricing.Implementation
{
    public class CalculateTotalPriceCommand
    {
        private readonly ProductManager _productManager;

        public CalculateTotalPriceCommand(ProductManager productManager)
        {
            _productManager = productManager;
        }

        public CalculateTotalPriceResponse Execute(CalculateTotalPriceRequest request)
        {
            throw new NotImplementedException();
        }
    }
}