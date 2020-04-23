using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;
using Xunit;

namespace TestNinja.UnitTests
{
    public class VideoServiceTests
    {
        [Fact]
        public void GetVideoTitle_EmptyFile_ReturnsError()
        {
            // Arrange
            var fileReader = new Mock<IFileReader>();
            fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var videoService = new VideoService(fileReader.Object);

            // Act
            var result = videoService.ReadVideoTitle();

            Assert.Contains("Error", result);
        }
    }
}
