using System;
using System.Collections.Generic;

#nullable disable

namespace Spotify.Exercise
{
    public partial class Artist
    {
        public Artist()
        {
            Albums = new List<Album>();
            Songs = new List<Song>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual List<Album> Albums { get; set; }
        public virtual List<Song> Songs { get; set; }
    }
}
