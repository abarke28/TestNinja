using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestNinja.UnitTests
{
    public class MathTests
    {
        [Fact]
        public void Add_WhenCalled_ReturnSumOfArguments()
        {
            // Arrange
            var math = new TestNinja.Fundamentals.Math();

            // Act
            var result = math.Add(1, 2);

            // Assert
            Assert.Equal(3, result);
        }

        [Theory]
        [InlineData(1,1,1)]
        [InlineData(1,2,2)]
        [InlineData(2,1,2)]
        public void Max_NumbersInEqual_ReturnLargerArgument(int value1, int value2, int expected)
        {
            // Arrange
            var math = new TestNinja.Fundamentals.Math();

            // Act
            var result = math.Max(value1, value2);
            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetOddNumbers_LimitGreaterThanZero_ReturnsOddNumbersFromZeroToLimit()
        {
            // Arrange
            var math = new TestNinja.Fundamentals.Math();

            // Act
            var result = math.GetOddNumbers(5);

            // Assert
            Assert.Equal(new[] { 1, 3, 5 }, result);
        }
    }
}