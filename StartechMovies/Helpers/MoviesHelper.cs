using Newtonsoft.Json;
using StartechMovies.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace StartechMovies.Helpers
{
    public class MoviesHelper
    {
        public static DictionaryMovieRepository InitMovies()
        {
            ///http://www.omdbapi.com/?t=fast+furious&y=2015&plot=full&r=json&type=movie&
            
            String moviesContent = File.ReadAllText(HttpContext.Current.Server.MapPath(@"~\App_Data\movies.json"));
            var movies = JsonConvert.DeserializeObject<Movie[]>(moviesContent);

            Dictionary<int, Movie> moviesDico = movies.ToDictionary(m => m.ID);
            var repo = new DictionaryMovieRepository(moviesDico);
            return repo;
        }

    }
}
