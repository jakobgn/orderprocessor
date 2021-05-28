using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using OrderProcessorApplication.Handlers;
using OrderProcessorApplication.Models;
using OrderProcessorApplication.Services;
using Xunit;

namespace OrderProcessApplication.Test
{
    public class MembershipActivationHandlerTests
    {
        [Fact]
        public void Should_Activate_When_MembershipActivation()
        {
            // Arrange
            var mock = new Mock<IMembershipService>();
            var order = Order.Create(new MembershipActivation());
            var sut = new MembershipActivationHandler(mock.Object);

            // Act
            sut.Process(order);

            // Assert
            mock.Verify(m => m.Activate(), Times.Once);
        }

        [Fact]
        public void Should_Not_Activate_When_Not_MembershipActivation()
        {
            // Arrange
            var mock = new Mock<IMembershipService>();
            var order = Order.Create(new PhysicalProduct());
            var sut = new MembershipActivationHandler(mock.Object);

            // Act
            sut.Process(order);

            // Assert
            mock.Verify(m => m.Activate(), Times.Never);
        }
        [Fact]
        public void Should_Call_Next_Handler_When_MembershipActivation()
        {
            // Arrange
            var order = Order.Create(new MembershipActivation());
            var sut = new MembershipActivationHandler(new Mock<IMembershipService>().Object);
            var mockHandler = new Mock<IHandler<Order>>();
            sut.SetNext(mockHandler.Object);

            // Act
            sut.Process(order);

            // Assert
            mockHandler.Verify(m => m.Process(order), Times.Once);
        }
        [Fact]
        public void Should_Call_Next_Handler_When_Not_MembershipActivation()
        {
            // Arrange
            var order = Order.Create(new PhysicalProduct());
            var sut = new MembershipActivationHandler(new Mock<IMembershipService>().Object);
            var mockHandler = new Mock<IHandler<Order>>();
            sut.SetNext(mockHandler.Object);

            // Act
            sut.Process(order);

            // Assert
            mockHandler.Verify(m => m.Process(order), Times.Once);
        }
    }
}
