using System;
using System.Collections.Generic;

#nullable disable

namespace Utility.Models
{
    public partial class PlaylistSong
    {
        public int Id { get; set; }
        public int? SongId { get; set; }
        public int? PlaylistId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
