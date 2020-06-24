using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Flix.API.Models;
using Flix.API.Repo.Users;

namespace Flix.API.Repo.Users
{


    public class PlaylistRepository : IPlaylistRepository
    {
        private  FlixContext context;

        public PlaylistRepository(FlixContext context)
        {
            this.context = context;
        }


    }
}
