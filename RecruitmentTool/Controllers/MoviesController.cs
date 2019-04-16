using Microsoft.AspNetCore.Mvc;
using RecruitmentTool.Services;

namespace RecruitmentTool.Controllers
{
    [Produces("application/json")]
    [Route("api/Movies")]
    public class MoviesController : Controller
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _moviesService.GetMovie(id);
            if (movie != null)
            {
                return Ok(movie);
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult ListMovies()
        {
            var movies = _moviesService.ListMovies();
            if (movies != null)
            {
                return Ok(movies);
            }

            return NotFound();
        }
    }
}
