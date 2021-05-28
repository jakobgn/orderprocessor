using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using OrderProcessorApplication.Handlers;
using OrderProcessorApplication.Models;
using Xunit;

namespace OrderProcessApplication.Test
{
    public class BookHandlerTests
    {
        [Fact]
        public void Should_Generate_Duplicate_Packing_Slip_When_Book()
        {
            // Arrange
            var mock = new Mock<IPackingService>();
            var order = Order.Create(new Book(""));
            var sut = new BookHandler(mock.Object);

            // Act
            sut.Process(order);

            // Assert
            mock.Verify(m => m.GenerateDuplicatePackingSlip(), Times.Once);
        }

        [Fact]
        public void Should_Not_Generate_Duplicate_Packing_Slip_When_Not_Book()
        {
            // Arrange
            var mock = new Mock<IPackingService>();
            var order = Order.Create(new PhysicalProduct());
            var sut = new BookHandler(mock.Object);

            // Act
            sut.Process(order);

            // Assert
            mock.Verify(m => m.GenerateDuplicatePackingSlip(), Times.Never);
        }
    }
}
