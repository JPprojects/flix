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
    public class PostController : ControllerBase
    {
        private IPlaylistRepository _playlistRepo;

        private readonly FlixContext _context;

        public PostController(IPlaylistRepository playlist, FlixContext context)
        {

            _playlistRepo = playlist;
            _context = context;
        }

    }
}