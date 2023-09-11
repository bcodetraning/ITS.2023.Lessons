using System;
using System.Collections.Generic;

#nullable disable

namespace Spotify.Exercise
{
    public partial class Album
    {
        public Album()
        {
            Songs = new List<Song>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? GenreId { get; set; }
        public int? ArtistId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual List<Song> Songs { get; set; }
    }
}
