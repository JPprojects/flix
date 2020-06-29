using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Flix.API.Repo;
using Flix.API.Repo.Users;
using Microsoft.AspNetCore.Http;
using Flix.API.Models;
using Flix.API.Services;

namespace Flix.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TheMoviedbController : Controller
    {
        [HttpGet]
        public IEnumerable<Result> GetListOfPopularMovies()
        {
            var popular  = new TheMoviedb();

            var items = popular.GetPopularity();
            var listofMovies = items.results;

            var listOfMTString = new List<Result>();

            foreach (var movie in listofMovies)
            {
                listOfMTString.Add(movie);
            }

            return listOfMTString;
        }
    }
}
