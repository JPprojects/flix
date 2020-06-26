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
    public class PostController : Controller
    {
        private IPlaylistRepository _playlistRepo;


        public PostController(IPlaylistRepository playlist)
        {

            _playlistRepo = playlist;
        }

        [HttpGet]
        public ActionResult<List<Playlist>> Index()
        {
            ViewBag.Posts = _playlistRepo.GetAllPlaylists().OrderByDescending(i => i.Id);
            ViewBag.User = HttpContext.Session.GetString("username");
            return View();
        }

        [HttpGet(Name = "GetPlaylistByUserId")]
        public ActionResult<IList<Playlist>> GetPlaylistByUserId()
        {
            var userid = HttpContext.Session.GetInt32("UserId");
            var item = _playlistRepo.GetAllPlaylistByUserId(userid).OrderByDescending(i => i.Id);
            if (item == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index", "Playlist");
        }


        [HttpPost]
        public IActionResult Create()
        {
            int userid = (int)HttpContext.Session.GetInt32("UserId");
            var title = Request.Form["title"];
            _playlistRepo.AddPlaylist(title, userid);
            return RedirectToAction("Index", "Playlist");
        }

        [HttpDelete]
        public IActionResult Delete(int id )
        {
            _playlistRepo.DeletePlayListById(id);
            return RedirectToAction("Index", "Playlist");
        }


        [HttpPut]
        public IActionResult Edit(int id)
        {
            var title = Request.Form["title"];
            _playlistRepo.EditPlayList(title, id);
            return RedirectToAction("Index", "Playlist");
        }




    }
}