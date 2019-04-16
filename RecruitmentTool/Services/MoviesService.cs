using System.Collections.Generic;
using RecruitmentTool.Models;
using RecruitmentTool.Repositories;

namespace RecruitmentTool.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository _moviesRepository;

        public MoviesService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public MovieModel GetMovie(int id)
        {
            return _moviesRepository.GetMovie(id);
        }

        public IEnumerable<MovieModel> ListMovies()
        {
            return _moviesRepository.ListMovies();
        }
    }
}
