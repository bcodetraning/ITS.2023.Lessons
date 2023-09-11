using System;
using System.Collections.Generic;

#nullable disable

namespace Spotify.Exercise
{
    public partial class Playlist
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? AccountId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Account Account { get; set; }
    }
}
