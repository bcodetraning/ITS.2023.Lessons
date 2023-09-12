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
           
        }

        public int Id { get; set; }
        public string Name { get; set; }
       

        public  List<Album> Albums { get; set; }
        public  List<Song> Songs { get; set; }
    }
}
