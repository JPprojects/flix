using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Flix.API.Repo;
using Flix.API.Repo.Users;
using Microsoft.AspNetCore.Http;
using Flix.API.Models;

namespace Flix.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WatchlistController : Controller
    {
        private IWatchlistRepository _watchlistRepository;
        private IPlaylistRepository _playlistRepo;

        public WatchlistController(IWatchlistRepository watchlistRepository,  IPlaylistRepository playlistRepo)
        {
            _watchlistRepository = watchlistRepository;
            _playlistRepo = playlistRepo;
        }


        [HttpGet]
        [Route("/Watchlist/ViewMoviesInPlaylist/{playlistId}")]
        public ActionResult<IList<Watchlist>> GetWatchlistByPlaylistId(int playlistId)
        {
            var item = _watchlistRepository.GetMoviesByPlaylistId(playlistId).OrderByDescending(i => i.Id);
            if (item == null)
            {
                return NotFound();
            }
            ViewBag.Playlist = item;
            return View("../User/ViewMoviesInPlaylist");
        }

        [HttpPost]
        public IActionResult Create(string movieTitle, int playlistId)
        {
            _watchlistRepository.AddMovie(movieTitle, playlistId);
            return RedirectToAction("Index", "Playlist");
        }


        [HttpDelete]
        public IActionResult Delet(int id)
        {
            _watchlistRepository.DeleteMovieFromPlaylist(id);
            return RedirectToAction("Index", "Playlist");
        }



    }
}