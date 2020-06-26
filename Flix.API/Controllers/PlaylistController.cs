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

        private readonly FlixContext _context;

        public PostController(IPlaylistRepository playlist, FlixContext context)
        {

            _playlistRepo = playlist;
            _context = context;
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


        [HttpPost(Name = "Create")]
        [Route("/Playlist/Create")]
        public IActionResult Create()
        {
            int userid = (int)HttpContext.Session.GetInt32("UserId");
            var title = Request.Form["title"];
            _playlistRepo.AddPlaylist(title, userid);
            return RedirectToAction("Playlist", "Home");
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