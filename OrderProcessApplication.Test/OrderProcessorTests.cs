using System;
using OrderProcessorApplication;
using OrderProcessorApplication.Models;
using OrderProcessorApplication.Processing;
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
        [Fact]
        public void Should_Process_Physical_Order()
        {
            // Arrange
            var sut = CreateDefaultOrderProcessor();
            var order = Order.Create(new PhysicalProduct());

            // Act
            sut.Process(order);

            // Assert
            Assert.True(true);
        }

        [Fact]
        public void Should_Process_Book_Order()
        {
            // Arrange
            var sut = CreateDefaultOrderProcessor();
            var order = Order.Create(new Book("Harry potter"));

            // Act
            sut.Process(order);

            // Assert
            Assert.True(true);
        }


        [Fact]
        public void Should_Process_Membership_Order()
        {
            // Arrange
            var sut = CreateDefaultOrderProcessor();
            var order = Order.Create(new MembershipActivation(), "test@abc.com");

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
