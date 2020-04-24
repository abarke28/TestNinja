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
    public class HouseKeeperHelperTests
    {
        [Fact]
        public void SendStatementEmails_WhenCalled_SendsEmails()
        {
            // Arrange
            var utilities = new Mock<IHouseKeeperUtilities>();
            utilities.Verify(u => u.EmailFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(1));
        }
    }
}
