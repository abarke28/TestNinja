using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;
using Xunit;

namespace TestNinja.UnitTests
{
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(3,"Fizz")]
        [InlineData(5,"Buzz")]
        [InlineData(15,"FizzBuzz")]
        [InlineData(4,"4")]
        public void GetOutput_WhenCalled_ReturnsCorrectOutput(int input, string expected)
        {
            // Arrange & Act
            var result = FizzBuzz.GetOutput(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
