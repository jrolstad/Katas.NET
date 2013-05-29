namespace SupermarketPricing.Implementation
{
    public class CalculateTotalPriceResponse
    {
        public decimal Amount { get; private set; }

        public CalculateTotalPriceResponse WithAmount(decimal value)
        {
            Amount = value;

            return this;
        }
    }
}