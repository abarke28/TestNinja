using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;
using Xunit;

namespace TestNinja.UnitTests
{
    public class DemeritPointsCalculatorTests
    {
        [Theory]
        [InlineData(20,0)]
        [InlineData(70,1)]
        [InlineData(80,3)]
        public void CalculateDemeritPoints_ValidSpeed_ProducesCorrectResponse(int speed, int expectedDemeritPoints)
        {
            // Arrange
            var demeritPointsCalculator = new DemeritPointsCalculator();

            // Act
            var result = demeritPointsCalculator.CalculateDemeritPoints(speed);

            // Assert
            Assert.Equal(expectedDemeritPoints, result);
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(310)]
        public void CalculateDemeritPoints_InvalidSpeed_ThrowsArgumentOutOfRangeException(int speed)
        {
            // Arrange
            var demeritPointsCalculator = new DemeritPointsCalculator();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(()=>demeritPointsCalculator.CalculateDemeritPoints(speed));
        }
    }
}