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

        public Playlist AddPlaylist(string title, int UserId)
        { 
            var playlist = new Playlist()
            {
                Title = title,
                UserId = UserId
            };
            context.Playlists.Add(playlist);
            context.SaveChanges();
            return playlist;
        }

        public Playlist DeletePlayListById(int Id)
        {
            var playlist = GetPlaylistById(Id);
            context.Playlists.Remove(playlist);
            context.SaveChanges();
            return playlist;
        }

        public Playlist EditPlayList(string title, int Id)
        {
            var playlist = GetPlaylistById(Id);
            playlist.Title = title;
            context.SaveChanges();
            return playlist;
        }

        public List<Playlist> GetAllPlaylistByUserId(int? Id)
        {
            return context.Playlists.Where(i => i.UserId == Id).ToList();
        }

        public List<Playlist> GetAllPlaylists()
        {
            return context.Playlists.ToList();
        }

        public Playlist GetPlaylistById(int Id)
        {
            return context.Playlists.Find(Id);
        }
    }
}
