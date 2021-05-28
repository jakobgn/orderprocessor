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
    public class MembershipUpgradeHandlerTests
    {
        [Fact]
        public void Should_Activate_When_MembershipUpgrade()
        {
            // Arrange
            var mock = new Mock<IMembershipService>();
            var order = Order.Create(new MembershipUpgrade());
            var sut = new MembershipUpgradeHandler(mock.Object);

            // Act
            sut.Process(order);

            // Assert
            mock.Verify(m => m.Upgrade(), Times.Once);
        }

        [Fact]
        public void Should_Not_Activate_When_Not_MembershipUpgrade()
        {
            // Arrange
            var mock = new Mock<IMembershipService>();
            var order = Order.Create(new PhysicalProduct());
            var sut = new MembershipUpgradeHandler(mock.Object);

            // Act
            sut.Process(order);

            // Assert
            mock.Verify(m => m.Upgrade(), Times.Never);
        }

        [Fact]
        public void Should_Call_Next_Handler_When_MembershipUpgrade()
        {
            // Arrange
            var order = Order.Create(new MembershipUpgrade());
            var sut = new MembershipUpgradeHandler(new Mock<IMembershipService>().Object);
            var mockHandler = new Mock<IHandler<Order>>();
            sut.SetNext(mockHandler.Object);

            // Act
            sut.Process(order);

            // Assert
            mockHandler.Verify(m => m.Process(order), Times.Once);
        }

        [Fact]
        public void Should_Call_Next_Handler_When_Not_MembershipUpgrade()
        {
            // Arrange
            var order = Order.Create(new PhysicalProduct());
            var sut = new MembershipUpgradeHandler(new Mock<IMembershipService>().Object);
            var mockHandler = new Mock<IHandler<Order>>();
            sut.SetNext(mockHandler.Object);

            // Act
            sut.Process(order);

            // Assert
            mockHandler.Verify(m => m.Process(order), Times.Once);
        }
    }
}
