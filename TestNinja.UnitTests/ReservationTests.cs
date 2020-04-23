using System;
using TestNinja;
using Xunit;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    public class ReservationTests
    {
        [Fact]
        public void CanCancelReservation_UserIsAdmin_ReturnsTrue()
        {
            // Arrange
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CanCancelReservation_ReservationIsMadeByUser_ReturnsTrue()
        {
            // Arrange
            var reservation = new Reservation { MadeBy = new User() };

            // Act
            var result = reservation.CanBeCancelledBy(reservation.MadeBy);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CanCancelReservation_NotReservationMakeOrAdmin_ReturnsFalse()
        {
            // Arrange
            var reservation = new Reservation { MadeBy = new User() };

            // Act
            var result = reservation.CanBeCancelledBy(new User {IsAdmin = false});

            // Assert
            Assert.False(result);
        }
    }
}
