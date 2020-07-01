using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Flix.API.Repo;
using Flix.API.Repo.Users;
using Microsoft.AspNetCore.Http;
using Flix.API.Models;
using System;

namespace Flix.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WatchlistController : Controller
    {
        private IWatchlistRepository _watchlistRepository;
        private IPlaylistRepository _playlistRepo;

        public WatchlistController(IWatchlistRepository watchlistRepository, IPlaylistRepository playlistRepo)
        {
            _watchlistRepository = watchlistRepository;
            _playlistRepo = playlistRepo;
        }


        [HttpGet]
        [Route("/Watchlist/GetWatchlistByPlaylistId/{playlistId}")]
        public ActionResult<IList<Watchlist>> GetWatchlistByPlaylistId(int playlistId)
        {
            HttpContext.Session.SetInt32("playlistId", playlistId);
            var item = _watchlistRepository.GetMoviesByPlaylistId(playlistId).OrderByDescending(i => i.Id);
            if (item == null)
            {
                return NotFound();
            }

            ViewBag.movieList = item;

            return View("../User/MoviesInsidePlaylist");
        }


        [HttpPost]
        [Route("Create")]
        public IActionResult Create()
        {
            string movieTitle = Request.Form["movie_title"];
            string posterPath = Request.Form["poster_path"];
            var playlist = Request.Form["playlist"];
            int playlistIdInt = Convert.ToInt32(playlist);
            _watchlistRepository.AddMovie(movieTitle, playlistIdInt, posterPath);
            return RedirectToAction("UserIndex", "Home");
        }


        
        [Route("/Watchlist/Delete/{id}")]
        public ActionResult<int> Delete(int id)
        {
            var playlistId = HttpContext.Session.GetInt32("playlistId");
            _watchlistRepository.DeleteMovieFromPlaylist(id);
            return RedirectToAction("GetWatchlistByPlaylistId", new {playlistId});
        }



    }
}