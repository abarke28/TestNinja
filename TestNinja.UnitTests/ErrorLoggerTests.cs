using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;
using Xunit;

namespace TestNinja.UnitTests
{
    public class ErrorLoggerTests
    {
        [Fact]
        public void Log_WhenCalled_ShouldSetLastErrorProperty()
        {
            // Arrange
            var errLogger = new ErrorLogger();

            // Act
            errLogger.Log("abc");

            // Assert
            Assert.Equal("abc", errLogger.LastError);
        }
    }
}
