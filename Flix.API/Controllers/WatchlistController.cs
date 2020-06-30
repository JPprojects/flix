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


        [HttpGet(Name = "GetWatchlistByPlaylistId")]
        public ActionResult<IList<Watchlist>> GetWatchlistByPlaylistId(int playlistId)
        {
            var item = _watchlistRepository.GetMoviesByPlaylistId(playlistId).OrderByDescending(i => i.Id);
            if (item == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index", "Playlist");
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


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _watchlistRepository.DeleteMovieFromPlaylist(id);
            return RedirectToAction("Index", "Playlist");
        }



    }
}