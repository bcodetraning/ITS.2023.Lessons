using System;
using System.Collections.Generic;

#nullable disable

namespace Utility.Models
{
    public partial class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Popularity { get; set; }
        public int? ArtistId { get; set; }
        public int? AlbumId { get; set; }
        public int? GenreId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Album Album { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
