using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Utility.Models;

namespace Utility.Read
{
    public class DataStore
    {
        HttpClient client = new HttpClient();
        

        public List<Artist> artists { get; set; }
        public List<Album> albums { get; set; }
        public List<Song> songs { get; set; }
        public List<Playlist> playlists { get; set; }
        public List<Radio> radios { get; set; }
        public List<Genre> genres { get; set; }

        public Utility.Models.Account account { get; set; }

        public static DataStore dataStore;
        

        DataStore()
        {
            client.BaseAddress = new Uri("http://localhost:5344/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            artists = new List<Artist>();
            albums = new List<Album>();
            playlists = new List<Playlist>();
            radios = new List<Radio>();
            account = new Account();
            genres= new List<Genre>();
            #region csv
            //songs = Utility.CreateObject<Song>(Utility.ReadfromFile(Settings.musicpath));
            //try
            //{
            //    radios = Utility.CreateObject<Radio>(Utility.ReadfromFile(Settings.radiospath));

            //}
            //catch
            //{
            //    Console.WriteLine("No radio found");
            //}
            //foreach (Song s in songs)
            //{
            //    s.CreateAlbum(albums);
            //}
            //foreach (Album album in albums)
            //{
            //    album.CreateArtist(artists);
            //}
            //foreach (Radio radio in radios)
            //{
            //    radio.SetList(artists);
            //}
            //try
            //{
            //    playlists = Utility.CreateObject<Playlist>(Utility.ReadfromFile(Settings.playlistpath));
            //    foreach (Playlist playlist in playlists)
            //    {
            //        playlist.GeneratefromFile(artists);
            //    }
            //}
            //catch
            //{
            //    Console.WriteLine("No playlist found");
            //}
            #endregion

            GetAllAlbums().GetAwaiter().GetResult();
            GetAllArtists().GetAwaiter().GetResult();
            GetAllSongs().GetAwaiter().GetResult();
            GetAllGenre().GetAwaiter().GetResult();
            GetAllPlaylists().GetAwaiter().GetResult();
            GetAllRadios().GetAwaiter().GetResult();
            //GetAccount().GetAwaiter().GetResult();


            SetSongProperties();
            SetGenreProperties();
            SetAlbumProperties();
            SetArtistAlbum();
            SetArtistSongs();
            //SetPlaylistAccount();
            //SetAccountPlaylists();
            SetRadiosGenre();
        }
        #region GetFromDB
        async Task GetAllSongs()
        {
            HttpResponseMessage response = await client.GetAsync($"api/DBSpotify/GetSongs");

            if (response.IsSuccessStatusCode)
                songs = await response.Content.ReadAsAsync<List<Song>>();
        }
        async Task GetAllArtists()
        {
            HttpResponseMessage response = await client.GetAsync($"api/DBSpotify/GetArtists");

            if (response.IsSuccessStatusCode)
                artists = await response.Content.ReadAsAsync<List<Artist>>();
        }
        async Task GetAllAlbums()
        {
            HttpResponseMessage response = await client.GetAsync($"api/DBSpotify/GetAlbums");

            if (response.IsSuccessStatusCode)
                albums = await response.Content.ReadAsAsync<List<Album>>();
        }
        async Task GetAllPlaylists()
        {
            HttpResponseMessage response = await client.GetAsync($"api/DBSpotify/GetPlaylists");

            if (response.IsSuccessStatusCode)
                playlists = await response.Content.ReadAsAsync<List<Playlist>>();
        }
        async Task GetAllRadios()
        {
            HttpResponseMessage response = await client.GetAsync($"api/DBSpotify/GetRadios");

            if (response.IsSuccessStatusCode)
                radios = await response.Content.ReadAsAsync<List<Radio>>();
        }
        async Task GetAccount()
        {
            HttpResponseMessage response = await client.GetAsync($"api/DBSpotify/GetAccount");

            if (response.IsSuccessStatusCode)
                account = await response.Content.ReadAsAsync<Account>();
        }
        async Task GetAllGenre()
        {
            HttpResponseMessage response = await client.GetAsync($"api/DBSpotify/GetGenres");

            if (response.IsSuccessStatusCode)
                genres = await response.Content.ReadAsAsync<List<Genre>>();
        }
        #endregion

        #region SetLocal
        void SetArtistAlbum()
        {
            foreach(var artist in artists)
            {
                artist.Albums.AddRange(albums.Where(x => x.ArtistId == artist.Id));
            }
        }
        void SetArtistSongs()
        {
            foreach (var artist in artists)
            {
                artist.Songs.AddRange(songs.Where(x => x.ArtistId == artist.Id));
            }
        }
        void SetAlbumProperties()
        {
            foreach (var album in albums)
            {
                album.Songs.AddRange(songs.Where(x => x.AlbumId == album.Id));
                album.Artist = artists.Where(x => x.Id == album.ArtistId).First();
                //album.Genre = genres.Where(x => x.Id == album.GenreId).First();
            }
        }
        void SetGenreProperties()
        {
            foreach (var genre in genres)
            {
                genre.Albums.AddRange(albums.Where(x => x.GenreId == genre.Id));
                genre.Songs.AddRange(songs.Where(x => x.GenreId == genre.Id));
                genre.Radios.AddRange(radios.Where(x => x.GenreId == genre.Id));
            }
        }
        void SetAccountPlaylists()
        {
            account.Playlists.AddRange(playlists.Where(x=>x.AccountId == account.Id));
        }
        void SetSongProperties()
        {
            foreach(var song in songs)
            {
                song.Artist = artists.Where(x=>x.Id == song.ArtistId).First();
                song.Album = albums.Where(x => x.Id == song.AlbumId).First();
                song.Genre = genres.Where(x => x.Id == song.GenreId).First();
            }
        }
        void SetPlaylistAccount()
        {
            foreach(var playlist in playlists)
            {
                playlist.Account = account;
            }
        }
        void SetRadiosGenre()
        {
            foreach (var radio in radios)
            {
                radio.Genre = genres.Where(x=>x.Id == radio.GenreId).First();
            }
        }
        #endregion

        public void ShowPlaylist()
        {
            Console.WriteLine("Tutte le playlist: ");
            foreach (var playlist in playlists)
            {
                Console.WriteLine($"Nome Playlist: {playlist.Title}  Autore: {playlist.Account.UserName}");
            }
        }
        public void ShowRadios()
        {
            Console.WriteLine("Tutte le radio: ");
            foreach (var radio in radios.OrderBy(x => x.Genre))
            {
                Console.WriteLine($"Nome Radio: {radio.Title} Genere: {radio.Genre}");
            }
        }

        public static DataStore GetInstance()
        {
            if(dataStore == null)
            {
                return dataStore = new DataStore(); 
            }
            else
            {
                return dataStore;
            }
            
        }
    }
}
