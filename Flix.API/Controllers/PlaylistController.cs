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
    public class PlaylistController : Controller
    {
        private IPlaylistRepository _playlistRepo;


        public PlaylistController(IPlaylistRepository playlist)
        {

            _playlistRepo = playlist;
        }

        [HttpGet(Name = "List")]
        [Route("/Playlist/List")]
        public ActionResult<List<Playlist>>List()
        {
            ViewBag.Posts = _playlistRepo.GetAllPlaylists().OrderByDescending(i => i.Id);
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View("../User/Playlists");
        }

        [HttpGet(Name = "GetPlaylistByUserId")]
        public IEnumerable<Playlist> GetPlaylistByUserId()
        {
            var userid = HttpContext.Session.GetInt32("UserId");
            var item = _playlistRepo.GetAllPlaylistByUserId(userid).OrderByDescending(i => i.Id);
            if (item == null)
            {
                return (IEnumerable<Playlist>)StatusCode(404);
            }
            return item;
        }


        [HttpPost(Name = "Create")]
        [Route("/Playlist/Create")]
        public IActionResult Create()
        {
            int userid = (int)HttpContext.Session.GetInt32("UserId");
            var title = Request.Form["title"];
            _playlistRepo.AddPlaylist(title, userid);
            return RedirectToAction("Playlist", "Home");
        }

        [HttpPost(Name = "Delete")]
        [Route("/Playlist/Delete/{id}")]
        public IActionResult Delete(int id )
        {
            _playlistRepo.DeletePlayListById(id);
            return RedirectToAction("Playlist", "Home");
        }


        [HttpPut]
        public IActionResult Edit(int id)
        {
            var title = Request.Form["title"];
            _playlistRepo.EditPlayList(title, id);
            return RedirectToAction("Index", "Playlist");
        }

        [Route("/Playlist/SelectPlaylist/{original_title}/{poster_path}")]
        public IActionResult SelectPlaylist(string original_title, string poster_path)
        {
            ViewBag.playlist = GetPlaylistByUserId();
            ViewBag.title = original_title;
            return View("../User/SelectPlaylist");
        }


    }
}