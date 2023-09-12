using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace Spotify.Exercise
{
    public partial class Song
    {
        public int Id { get; set; }
        public int Popularity { get; set; }        
        public string Title { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }

        public Album Albums;
        public Artist Artists;
        public Genre Genres;

       
        public void SetAlbumToSong(List<Album> Albums)
        {
            this.Albums = Albums.Where(s=> s.Songs.Contains(this)).FirstOrDefault();  
        }
        public void SetArtistToSong(List<Artist> Artists)
        {
            this.Artists = Artists.Where(s => s.Songs.Contains(this)).FirstOrDefault();
        }

    }
}
