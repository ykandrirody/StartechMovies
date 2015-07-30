using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartechMovies.Models
{
    public class DictionaryMovieRepository : IMovieRepository
    {
        int nextID = 0;
        Dictionary<int, Movie> movies = new Dictionary<int, Movie>();

        public DictionaryMovieRepository(Dictionary<int, Movie> movies)
        {
            this.movies = movies;
        }

        public IEnumerable<Movie> Get()
        {
            return movies.Values.OrderBy(movie => movie.ID);
        }

        public bool TryGet(int id, out Movie movie)
        {
            return movies.TryGetValue(id, out movie);
        }

        public Movie Add(Movie movie)
        {
            movie.ID = movies.Values.Max(r => r.ID) + 1;
            movies[movie.ID] = movie;
            return movie;
        }

        public bool Delete(int id)
        {
            return movies.Remove(id);
        }

        public bool Update(Movie movie)
        {
            bool update = movies.ContainsKey(movie.ID);
            movies[movie.ID] = movie;
            return update;
        }

    }
}