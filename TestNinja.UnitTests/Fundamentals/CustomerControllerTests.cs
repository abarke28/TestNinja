using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;
using Xunit;

namespace TestNinja.UnitTests
{
    public class CustomerControllerTests
    {
        [Fact]
        public void GetCustomer_IdIsZero_ReturnsNotFound()
        {
            // Arrange
            var customerController = new CustomerController();

            // Act
            var result = customerController.GetCustomer(0);

            // Assert   
            Assert.IsType(typeof(NotFound), result);
        }

        [Fact]
        public void GetCustomer_IdIsNotZero_ReturnsOk()
        {
            // Arrange
            var customerController = new CustomerController();

            // Act
            var result = customerController.GetCustomer(5);

            // Assert
            Assert.IsType(typeof(Ok), result);

        }
    }
}
