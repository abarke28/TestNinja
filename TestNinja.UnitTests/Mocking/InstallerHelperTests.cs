using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;
using Xunit;

namespace TestNinja.UnitTests.Mocking
{
    public class InstallerHelperTests
    {
        [Fact]
        public void DownloadInstaller_DownloadFails_ReturnsFalse()
        {
            // Arrange
            var fileDownloader = new Mock<IFileDownloader>();
            fileDownloader.Setup(f => f.DownloadFile(It.IsAny<string>(),It.IsAny<string>())).Throws(new WebException());

            var installerHelper = new InstallerHelper(null, fileDownloader.Object);

            // Act
            var result = installerHelper.DownloadInstaller("customerName", "installerName");

            // Assert
            Assert.Equal(false, result);
        }

        [Fact]
        public void DownloadInstaller_DownloadSucceeds_ReturnsTrue()
        {
            // Arrange
            var fileDownloader = new Mock<IFileDownloader>();

            var installerHelper = new InstallerHelper(null, fileDownloader.Object);

            // Act
            var result = installerHelper.DownloadInstaller("customerName", "installerName");

            // Assert
            Assert.Equal(true, result);
        }
    }
}
