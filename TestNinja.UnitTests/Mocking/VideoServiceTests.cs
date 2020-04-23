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

        [Fact]
        public void GetUnprocessedVideoAsCsv_RepositoryIsEmpty_ReturnsEmptyString()
        {
            // Arrange
            var repo = new Mock<IVideoProcessedFilter>();
            repo.Setup(r => r.GetProcessedVideos()).Returns(new List<Video>());

            var videoService = new VideoService(null, repo.Object);

            // Act
            var result = videoService.GetUnprocessedVideosAsCsv();

            // Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void GetUnprocessedVideoAsCsv_RepositoryHaseOneOrMoreItems_ReturnsJoinedList()
        {
            // Arrange
            var repo = new Mock<IVideoProcessedFilter>();
            repo.Setup(r => r.GetProcessedVideos()).Returns(new List<Video>
            {
                new Video {Id = 1},
                new Video {Id = 2},
                new Video {Id = 3}
            });

            var videoService = new VideoService(null, repo.Object);

            // Act
            var result = videoService.GetUnprocessedVideosAsCsv();

            // Assert
            Assert.Equal("1,2,3", result);
        }
    }
}
