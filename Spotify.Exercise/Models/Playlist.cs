using System;
using System.Collections.Generic;

#nullable disable

namespace Utility.Models
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
