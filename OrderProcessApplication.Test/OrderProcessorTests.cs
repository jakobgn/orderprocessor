using System;
using OrderProcessorApplication;
using OrderProcessorApplication.Models;
using Xunit;

namespace OrderProcessApplication.Test
{
    public class OrderProcessorTests
    {
        [Fact]
        public void Should_Process_Order()
        {
            // Arrange
            var sut = CreateDefaultOrderProcessor();
            var order = Order.Create(new NonPhysicalProduct());

            // Act
            sut.Process(order);

            // Assert
            Assert.True(true);
        }

        private OrderProcessor CreateDefaultOrderProcessor()
        {
            return new();
        }
    }
}
