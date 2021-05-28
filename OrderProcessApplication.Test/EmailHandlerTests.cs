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
    public class EmailHandlerTests
    {
        [Fact]
        public void Should_Send_Email_When_MembershipActivation()
        {
            // Arrange
            var mock = new Mock<IMembershipService>();
            var order = Order.Create(new MembershipActivation());
            var sut = new EmailHandler(mock.Object);

            // Act
            sut.Process(order);

            // Assert
            mock.Verify(m => m.SendEmail(order.Email), Times.Once);
        }

        [Fact]
        public void Should_Send_Email_When_MembershipUpgrade()
        {
            // Arrange
            var mock = new Mock<IMembershipService>();
            var order = Order.Create(new MembershipUpgrade());
            var sut = new EmailHandler(mock.Object);

            // Act
            sut.Process(order);

            // Assert
            mock.Verify(m => m.SendEmail(order.Email), Times.Once);
        }

        [Fact]
        public void Should_Not_Send_Email_When_Not_Membership()
        {
            // Arrange
            var mock = new Mock<IMembershipService>();
            var order = Order.Create(new PhysicalProduct());
            var sut = new EmailHandler(mock.Object);

            // Act
            sut.Process(order);

            // Assert
            mock.Verify(m => m.SendEmail(order.Email), Times.Never);
        }

    }
}
