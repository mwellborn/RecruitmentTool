using System;
using System.Collections.Generic;
using System.Linq;
using RecruitmentTool.Models;

namespace RecruitmentTool.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        public MoviesRepository()
        {
        }

        public MovieModel GetMovie(int id)
        {
            return ListMovies().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<MovieModel> ListMovies()
        {
            return new List<MovieModel>()
            {
                new MovieModel()
                {
                     Id = 1,
                     Name = "Star Wars",
                     Rating = "PG"
                },
                new MovieModel()
                {
                     Id = 2,
                     Name = "The Empire Strikes Back",
                     Rating = "PG"
                },
                new MovieModel()
                {
                     Id = 3,
                     Name = "Return of the Jedi",
                     Rating = "PG-13"
                }
            };
        }
    }
}
