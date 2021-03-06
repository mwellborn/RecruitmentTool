﻿using System.Collections.Generic;
using RecruitmentTool.Models;

namespace RecruitmentTool.Repositories
{
    public interface IMoviesRepository
    {
        /// <summary>
        /// Gets the movie.
        /// </summary>
        /// <returns>The movie.</returns>
        /// <param name="id">Identifier.</param>
        MovieModel GetMovie(int id);

        /// <summary>
        /// Lists the movies.
        /// </summary>
        /// <returns>The movies.</returns>
        IEnumerable<MovieModel> ListMovies();
    }
}
