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
        public string Genre { get; set; }
        public string Artist { get; set; }
        public DateTime? CreatedAt { get; set; }

       
        
        public virtual List<Song> Songs { get; set; }
    }
}
