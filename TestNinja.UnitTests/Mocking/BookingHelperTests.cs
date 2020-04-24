using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;
using Xunit;

namespace TestNinja.UnitTests.Mocking
{
    public class BookingHelperTests
    {
        [Fact]
        public void OverLappingBookingsExist_BookingIsCancelled_ReturnsEmptyString()
        {
            // Arrange & Act
            var result = BookingHelper.OverlappingBookingsExist(new Booking { Status = "Cancelled" });

            // Act
            Assert.Equal("", result);
        }

        [Fact]
        public void OverlappingBookingsExist_NoOverlappingBookings_ReturnsEmptyString()
        {

        }
    }
}