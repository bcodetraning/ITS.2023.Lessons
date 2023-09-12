using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;


namespace Spotify.Exercise
{   
    public static class Utility 
    {
       
        public static List<string> ReadfromFile(string path) 
        {
            var lines = File.ReadAllLines(path).ToList();
            return lines;
        }
        public static List<T> CreateObject<T>(List<string> lines) where T : class, new()
        {
            List<T> list = new List<T>();
            string[] headers = lines.ElementAt(0).Split(',');
            lines.RemoveAt(0); // Rimuovo la prima riga (nome colonne) del mio datasource
            bool corretto = false;
            bool p = true;
            T entry = new T(); // Creo istanza per poter estrarre le properties
            PropertyInfo[] prop = entry
                            .GetType() // Prendo il tipo
                                    .GetProperties(); // Prendo le sue properties 

            if (true)
            {
                for (int i = 0; i < prop.Length; i++) // Ciclo le properties dell'oggetto  T
                {                   
                    if (prop.ElementAt(i).Name == headers[i]) // ciclo le colonne e le properties insieme
                    {                        
                        corretto = true;      
                    }
                    else p = false; // S eha fallito almeno una volta, setto a false
                }
            }
            if (corretto && p)
            {
                foreach (var line in lines)
                {
                    int j = 0;
                    string[] columns = line.Split(',');
                    entry = new T(); // Per ogni riga del CSV creo un nuovo oggetto di tipo T
                    foreach (var col in columns) // cicle le colonne del CSV
                    {
                        entry.GetType()
                            .GetProperty(headers[j])
                            .SetValue(entry, //  il nuovo oggetto T che ho creato
                            Convert
                            .ChangeType(col, //   singola cella del CSV (il valore da settare )
                            entry.GetType().GetProperty(headers[j]) // Prende la property col nome del Header corrente 
                                .PropertyType)//ritorna il tipo del property 
                            ); 

                        j++;
                    }
                    list.Add(entry);
                }
            }
            else Console.WriteLine("le proprietà nel file non corrispondono a proprietà oggetto");

            return list;
        }
        public static void WriteonFile<T>(string path, List<T> ts) where T : class, new()
        {
            List<string> list = new List<string>();
            StringBuilder sb = new StringBuilder();
            var cols = ts[0].GetType().GetProperties();

            if (File.Exists(path))
            {
                File.Delete(path);
            }
            foreach (var col in cols)// cicla tutte le Entity della classe in oggetto
            {
                sb.Append(col.Name);
                sb.Append(',');
            }

            list.Add(sb.ToString().Substring(0, sb.Length - 1));
            foreach (var row in ts)
            {

                sb = new StringBuilder();
                foreach (var col in cols)// cicla tutte le Entity della classe in oggetto
                {

                    sb.Append(col.GetValue(row));
                    sb.Append(',');


                }
                list.Add(sb.ToString().Substring(0, sb.Length - 1));
            }
            File.AppendAllLines(path, list);
        }
        //public static void GetSettings()
        //{
        //    var services = new ServiceCollection();
        //    IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        //    services.AddSingleton<Settings>();
        //    OptionsConfigurationServiceCollectionExtensions.Configure<Settings>(services, config.GetSection("settings"));
        //    config.GetRequiredSection("settings").Get<Settings>();
        //}
        public static List<Artist> GetTopFiveArtists()
        {
            List<Artist> artistList = new List<Artist>();
            Dictionary<Artist, int> sortedArtists = new Dictionary<Artist, int>();
            DataStore db = DataStore.GetInstance();
            foreach (Artist artist in db.artists)
            {
                int totalPopularity = 0;
                foreach (var song in db.songs.Where(song => song.Artists.Name.Equals(artist.Name)))
                {
                    totalPopularity += song.Popularity;
                }
                sortedArtists.Add(artist, totalPopularity);
            }
            foreach (var art in sortedArtists.OrderBy(x => x.Value).Reverse().Take(5))
            {
                artistList.Add(db.artists.Where(i => i.Name == art.Key.Name).FirstOrDefault());
            }
            return artistList;
        }
        public static List<Song> GetTopFiveSongs()
        {

            List<Song> output = new List<Song>();

            foreach (var album in MediaPlayer.GetInstance().currentArtist.Albums)
            {
                foreach (var song in album.Songs)
                {
                    output.Add(song);
                }
            }
            return output.OrderBy(x => x.Popularity).Reverse().Take(5).ToList();
        }
        public static Song FindSong(string input)
        {
            foreach (var song in DataStore.GetInstance().songs)
            {
                if (song.Title.Equals(input))
                {
                    return song;
                }
            }
            return null;
        }
        public static Artist FindArtist(string input)
        {
            foreach (var artist in DataStore.GetInstance().artists)
            {
                if (artist.Name.Equals(input))
                {
                    return artist;
                }
            }
            return null;
        }
        public static Album FindAlbum(string input)
        {
            foreach (var album in DataStore.GetInstance().albums)
            {
                if (album.Title.Equals(input))
                {
                    return album;
                }
            }
            return null;
        }
        public static Radio FindRadio(string input)
        {
            foreach (var radio in DataStore.GetInstance().radios)
            {
                if (radio.Title.Equals(input))
                {
                    return radio;
                }
            }
            return null;
        }
        public static Playlist FindPlaylist(string input)
        {
            foreach (var playlist in DataStore.GetInstance().playlists)
            {
                if (playlist.Title.Equals(input))
                {
                    return playlist;
                }
            }
            return null;
        }
        public static List<Album> GetAlbumsBySong(List<Song> Songs)
        {
             return Songs.GroupBy(s => s.Album)
                  .Select(group => new Album
                  {
                      Title = group.Key,
                      Songs = group.Select(i => i).ToList(),
                      Artist = group.Select(i => i.Artist).Distinct().FirstOrDefault(),
                      Genre = group.Select(i => i.Genre).Distinct().FirstOrDefault(),
                  }).ToList();             

        }
        public static List<Artist> GetArtistByAlbums(List<Album> Albums)
        {
            return Albums.GroupBy(s => s.Artist)
                .Select(group => new Artist
                {
                    Name = group.Key,
                    Albums = group.Select(i => i).ToList(),
                    Songs =  group.SelectMany(i => i.Songs).ToList() 

                }).ToList();
        }

    }
    
}
