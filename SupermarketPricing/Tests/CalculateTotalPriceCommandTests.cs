using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SupermarketPricing.Implementation;

namespace SupermarketPricing.Tests
{
    [TestFixture]
    public class CalculateTotalPriceCommandTests
    {

        [Test]
        [TestCase("Can of Beans",1,0.65)]
        [TestCase("Can of Beans",3,1.00)]
        [TestCase("Bananas",1,1.99)]
        [TestCase("Bananas",2,3.98)]
        [TestCase("Soda",1,1.50)]
        [TestCase("Soda",2,3.00)]
        [TestCase("Soda",3,3.00)]
        public void When_calculating_price_then_it_is_calculated_correctly(string itemName, int amount, double totalAmount)
        {
            // Arrange
            var request = new CalculateTotalPriceRequest()
                .WithProduct(itemName)
                .WithNumberOfProduct(amount);

            var productManager = new ProductManager();
            var command = new CalculateTotalPriceCommand(productManager);

            // Act
            var result = command.Execute(request);

            // Assert
            Assert.That(result.Amount,Is.EqualTo(totalAmount));
        } 

    }
}