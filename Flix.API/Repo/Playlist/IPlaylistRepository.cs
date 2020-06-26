using System;
using System.Collections;
using System.Collections.Generic;
using Flix.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flix.API.Repo.Users
{
    public interface IPlaylistRepository
    {
        List<Playlist> GetAllPlaylists();
        Playlist GetPlaylistById(int Id);
        Playlist AddPlaylist(string title, int UserId);
        Playlist DeletePlayListById(int Id);
        void EditPlayList(string title, int Id);
        List<Playlist> GetAllPlaylistByUserId(int? Id);
    }
}
