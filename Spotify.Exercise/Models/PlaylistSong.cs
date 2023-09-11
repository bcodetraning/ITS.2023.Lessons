using System;
using System.Collections.Generic;

#nullable disable

namespace Spotify.Exercise
{
    public partial class PlaylistSong
    {
        public int Id { get; set; }
        public int? SongId { get; set; }
        public int? PlaylistId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
