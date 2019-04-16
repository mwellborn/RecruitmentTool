using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using RecruitmentTool.Models;
using RecruitmentTool.Repositories;
using RecruitmentTool.Services;

namespace RecruitmentTool.UnitTests.Services
{
    public class MoviesServicesTests
    {
        [Test]
        public void GetMovieReturnsNull()
        {
            // Arrange
            var id = 1;

            var mockMoviesRepository = new Mock<IMoviesRepository>(MockBehavior.Strict);
            mockMoviesRepository
                .Setup(x => x.GetMovie(id))
                .Returns((MovieModel)null);

            var moviesService = new MoviesService(mockMoviesRepository.Object);

            // Act
            var response = moviesService.GetMovie(id);

            // Assert
            mockMoviesRepository.VerifyAll();

            Assert.IsNull(response);
        }


        [Test]
        public void GetMovieReturnsMovie()
        {
            // Arrange
            var id = 1;

            var mockMoviesRepository = new Mock<IMoviesRepository>(MockBehavior.Strict);
            mockMoviesRepository
                .Setup(x => x.GetMovie(id))
                .Returns(new MovieModel()
                {
                    Id = id,
                    Name = "name",
                    Rating = "rating"
                });

            var moviesService = new MoviesService(mockMoviesRepository.Object);

            // Act
            var response = moviesService.GetMovie(id);

            // Assert
            mockMoviesRepository.VerifyAll();

            Assert.IsNotNull(response);

            Assert.AreEqual(id, response.Id);
        }

        [Test]
        public void ListMoviesReturnsNull()
        {
            // Arrange
            var mockMoviesRepository = new Mock<IMoviesRepository>();

            var moviesService = new MoviesService(mockMoviesRepository.Object);

            // Act
            var response = moviesService.ListMovies();

            // Assert
            mockMoviesRepository.VerifyAll();

            Assert.IsNull(response);
        }

        [Test]
        public void ListMoviesReturnsMovies()
        {
            // Arrange
            var id1 = 1;
            var id2 = 2;

            var mockMoviesRepository = new Mock<IMoviesRepository>(MockBehavior.Strict);
            mockMoviesRepository
                .Setup(x => x.ListMovies())
                .Returns(new List<MovieModel>()
                {
                    new MovieModel()
                    {
                        Id = id1,
                        Name = "name",
                        Rating = "rating"
                    },
                    new MovieModel()
                    {
                        Id = id2,
                        Name = "name",
                        Rating = "rating"
                    }
                });

            var moviesService = new MoviesService(mockMoviesRepository.Object);

            // Act
            var response = moviesService.ListMovies();

            // Assert
            mockMoviesRepository.VerifyAll();

            Assert.IsNotNull(response);
            Assert.AreEqual(id1, response.FirstOrDefault().Id);
        }
    }
}
