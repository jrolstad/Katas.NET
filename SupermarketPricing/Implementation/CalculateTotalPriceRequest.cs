namespace SupermarketPricing.Implementation
{
    public class CalculateTotalPriceRequest
    {
        public string ProductName { get; private set; }

        public decimal NumberofProduct { get; private set; }

        public CalculateTotalPriceRequest WithProduct(string value)
        {
            ProductName = value;

            return this;
        }

        public CalculateTotalPriceRequest WithNumberOfProduct(decimal value)
        {
            NumberofProduct = value;

            return this;
        }
    }
}