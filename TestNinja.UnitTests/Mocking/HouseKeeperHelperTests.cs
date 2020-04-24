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
            utilities.Setup(u => u.SaveStatement(It.IsAny<int>(), It.IsAny<string>(), DateTime.Today)).Returns("abc");
            
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(u => u.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
                new Housekeeper { Email = "a", StatementEmailBody = "b", FullName = "c", Oid = 1 },
                new Housekeeper { Email = "a", StatementEmailBody = "b", FullName = "c", Oid = 2 }
            }.AsQueryable());

            HousekeeperHelper.SendStatementEmails(DateTime.Today, utilities.Object, unitOfWork.Object);

            utilities.Verify(u => u.SaveStatement(It.IsAny<int>(), It.IsAny<string>(), DateTime.Today),Times.Exactly(2));
            utilities.Verify(u => u.EmailFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),Times.Exactly(2));
        }
    }
}