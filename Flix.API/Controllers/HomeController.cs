using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Flix.API.Models;
using Microsoft.AspNetCore.Http;
using Flix.API.Services;

namespace Flix.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var api = new TheMoviedb();
            api.GetPopularity();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult UserIndex()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            var moviedb = new TheMoviedbController();
            var movielist = moviedb.GetListOfPopularMovies();
            ViewBag.movieList = movielist;
            return View("../User/Welcome");
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        public IActionResult Playlist()
        {
            return RedirectToAction("List", "Playlist"); 
        }

        [Route("/Home/SelectPlaylist/{original_title}/{poster_path}")]
        public IActionResult SelectPlaylist(string original_title, string poster_path)
        {
            ViewBag.title = original_title;
            return View("../User/SelectPlaylist");
        }
    }
}
