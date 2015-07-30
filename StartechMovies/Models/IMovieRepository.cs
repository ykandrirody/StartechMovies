using System.Collections.Generic;

namespace StartechMovies.Models
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> Get();
        bool TryGet(int id, out Movie movie);
        Movie Add(Movie movie);
        bool Delete(int id);
        bool Update(Movie movie);
    }
}
