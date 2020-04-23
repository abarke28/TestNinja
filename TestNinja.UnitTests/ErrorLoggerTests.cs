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

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            // Arrange
            var errorLogger = new ErrorLogger();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => errorLogger.Log(error));
        }

        [Fact]
        public void Log_WhenCalled_ShouldRaiseErrorLoggedEvent()
        {
            // Arrange
            var errorLogger = new ErrorLogger();

            // Act
            var guid = new Guid();
            errorLogger.ErrorLogged += (sender, args) => { guid = args; };
            errorLogger.Log("abc");

            // Assert
            Assert.NotEqual(Guid.Empty, guid);
        }
    }
}