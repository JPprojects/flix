﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flix.API.Models
{
    public class Watchlist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string MovieTitle { get; set; }

        [ForeignKey("Playlist")]
        public int PlaylistId { get; set; }

        public virtual Playlist Playlist { get; set; }
       public string PosterPath { get; set; }

    }
}