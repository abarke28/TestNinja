using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;
using Xunit;

namespace TestNinja.UnitTests
{
    public class HtmlFormatterTests
    {
        [Fact]
        public void FormatAsBold_WhenCalled_ReturnsStringEnclosedWithBoldTags()
        {
            // Arrange
            var htmlForamatter = new HtmlFormatter();

            // Act
            var result = htmlForamatter.FormatAsBold("abc");

            // Assert
            Assert.StartsWith("<strong>", result);
            Assert.EndsWith("</strong>", result);
            Assert.Contains("abc", result);
        }
    }
}
