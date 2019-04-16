using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using RecruitmentTool.Controllers;
using RecruitmentTool.Models;
using RecruitmentTool.Services;

namespace RecruitmentTool.UnitTests.Controllers
{
    public class MoviesControllerTests
    {
        [Test]
        public void GetMovieReturnsNotFound()
        {
            // Arrange
            var id = 1;

            var mockMoviesService = new Mock<IMoviesService>(MockBehavior.Strict);
            mockMoviesService
                .Setup(x => x.GetMovie(id))
                .Returns((MovieModel)null);

            var moviesController = new MoviesController(mockMoviesService.Object);

            // Act
            var response = moviesController.GetMovie(id) as NotFoundResult;

            // Assert
            mockMoviesService.VerifyAll();

            Assert.IsNotNull(response);
        }

        [Test]
        public void GetMovieReturnsMovie()
        {
            // Arrange
            var id = 1;

            var mockMoviesService = new Mock<IMoviesService>(MockBehavior.Strict);
            mockMoviesService
                .Setup(x => x.GetMovie(id))
                .Returns(new MovieModel()
                { 
                     Id = id,
                     Name = "name",
                     Rating = "rating"
                });

            var moviesController = new MoviesController(mockMoviesService.Object);

            // Act
            var response = moviesController.GetMovie(id) as OkObjectResult;

            // Assert
            mockMoviesService.VerifyAll();

            Assert.IsNotNull(response);

            var movie = response.Value as MovieModel;
            Assert.AreEqual(id, movie.Id);
        }

        [Test]
        public void ListMoviesReturnsNotFound()
        {
            // Arrange
            var mockMoviesService = new Mock<IMoviesService>(MockBehavior.Strict);
            mockMoviesService
                .Setup(x => x.ListMovies())
                .Returns((IEnumerable<MovieModel>)null);

            var moviesController = new MoviesController(mockMoviesService.Object);

            // Act
            var response = moviesController.ListMovies() as NotFoundResult;

            // Assert
            mockMoviesService.VerifyAll();

            Assert.IsNotNull(response);
        }

        [Test]
        public void ListMoviesReturnsMovies()
        {
            // Arrange
            var id1 = 1;
            var id2 = 2;

            var mockMoviesService = new Mock<IMoviesService>(MockBehavior.Strict);
            mockMoviesService
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

            var moviesController = new MoviesController(mockMoviesService.Object);

            // Act
            var response = moviesController.ListMovies() as OkObjectResult;

            // Assert
            mockMoviesService.VerifyAll();

            Assert.IsNotNull(response);

            var movies = response.Value as IEnumerable<MovieModel>;
            Assert.AreEqual(id1, movies.FirstOrDefault().Id);
        }
    }
}
