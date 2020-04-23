using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;
using Xunit;

namespace TestNinja.UnitTests.Mocking
{
    public class OrderServiceTests
    {
        [Fact]
        public void PlaceOrder_WhenCalled_StoresOrder()
        {
            // Arrange
            var storage = new Mock<IStorage>();
            var orderService = new OrderService(storage.Object);
            var order = new Order();

            // Act
            orderService.PlaceOrder(order);

            // Assert
            storage.Verify(s => s.Store(order));
        }
    }
}
