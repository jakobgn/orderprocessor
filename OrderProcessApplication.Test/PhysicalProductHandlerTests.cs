﻿using Moq;
using OrderProcessorApplication.Handlers;
using OrderProcessorApplication.Models;
using OrderProcessorApplication.Services;
using Xunit;

namespace OrderProcessApplication.Test
{
    public class PhysicalProductHandlerTests
    {
        [Fact]
        public void Should_Generate_Duplicate_Packing_Slip_When_PhysicalProduct()
        {
            // Arrange
            var mock = new Mock<IPackingService>();
            var order = Order.Create(new PhysicalProduct());
            var sut = new PhysicalProductHandler(mock.Object);

            // Act
            sut.Process(order);

            // Assert
            mock.Verify(m => m.GeneratePackingSlip(), Times.Once);
        }

        [Fact]
        public void Should_Not_Generate_Duplicate_Packing_Slip_When_Not_PhysicalProduct()
        {
            // Arrange
            var mock = new Mock<IPackingService>();
            var order = Order.Create(new NonPhysicalProduct());
            var sut = new PhysicalProductHandler(mock.Object);

            // Act
            sut.Process(order);

            // Assert
            mock.Verify(m => m.GeneratePackingSlip(), Times.Never);
        }
        [Fact]
        public void Should_Call_Next_Handler_When_PhysicalProduct()
        {
            // Arrange
            var order = Order.Create(new PhysicalProduct());
            var sut = new PhysicalProductHandler(new Mock<IPackingService>().Object);
            var mockHandler = new Mock<IHandler<Order>>();
            sut.SetNext(mockHandler.Object);

            // Act
            sut.Process(order);

            // Assert
            mockHandler.Verify(m => m.Process(order), Times.Once);
        }
        [Fact]
        public void Should_Call_Next_Handler_When_Not_PhysicalProduct()
        {
            // Arrange
            var order = Order.Create(new PhysicalProduct());
            var sut = new PhysicalProductHandler(new Mock<IPackingService>().Object);
            var mockHandler = new Mock<IHandler<Order>>();
            sut.SetNext(mockHandler.Object);

            // Act
            sut.Process(order);

            // Assert
            mockHandler.Verify(m => m.Process(order), Times.Once);
        }
    }
}
