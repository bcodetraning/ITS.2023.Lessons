using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Spotify.Exercise
{
    public static class UserInterface
    {
        public static void SourceSelectionInterface()
        {
            string input;
            
            do
            {
                Console.Clear();
                Console.WriteLine("Benvenuti in Spotify");
                Console.WriteLine("Premere S per caricare da Social");
                Console.WriteLine("Premere L per caricare da Locale");
                input = Console.ReadLine().ToLower();
            } while (input != "l" && input != "s");
            Authentication.SourceSelection(input);
            if (Authentication.dataSource.StartsWith("local"))
            {
                Console.WriteLine("Musica caricata da locale");
                var data = DataStore.GetInstance();
            }
            else
            {
                Console.WriteLine("Musica caricata dalla rete");
                var data = DataStore.GetInstance();
            }

        }
        public static void Router(string input)
        {
            MediaPlayer media = MediaPlayer.GetInstance();
            do
            {
                switch (input)
                {
                    case "m": //Music
                        media.currentPages.Clear();
                        media.currentPages.Add("m");
                        input = LocaleHomePage();
                        break;
                    case "o":
                        media.currentPages.Clear();
                        media.currentPages.Add("o");
                        media.currentPages.Add("e");
                        input = AudioPage();
                        break;
                    case "e":
                        media.currentPages.Clear();
                        media.currentPages.Add("o");
                        media.currentPages.Add("e");
                        input = AudioPage();
                        break;
                    case "u":
                        media.currentPages.Clear();
                        media.currentPages.Add("o");
                        media.currentPages.Add("u");
                        input = ProfilePage();
                        break;
                    case "c":
                        media.currentPages.Clear();
                        media.currentPages.Add("o");
                        media.currentPages.Add("c");
                        input = SocialPage();
                        break;
                    case "j": //Back
                        input = MediaPlayer.GetInstance().Back();
                        break;
                    case "k": //Next
                        input = MediaPlayer.GetInstance().Next();
                        break;
                    case "w"://Pause
                        MediaPlayer.GetInstance().Pause();
                        input = media.currentPages.Last();
                        break;
                    case "t"://Stop
                        MediaPlayer.GetInstance().Stop();
                        input = media.currentPages.Last();
                        break;
                        
                    case "s": //All Songs
                        if (MediaPlayer.GetInstance().currentPages.Count > 1)
                        {
                            //MediaPlayer.GetInstance().currentPages.RemoveAt(MediaPlayer.GetInstance().currentPages.Count - 1);
                            media.currentPages.Clear();
                            media.currentPages.Add("m");
                        }
                        if (MediaPlayer.GetInstance().currentPages.Contains("m"))
                        {
                            media.currentPages.Add("s");
                            input = LocaleAllSongs();
                        }
                        else { input = LocaleHomePage(); }
                        break;
                    case "artistMenu":
                        if (MediaPlayer.GetInstance().currentPages.Count > 2)
                        {
                            MediaPlayer.GetInstance().currentPages.RemoveAt(MediaPlayer.GetInstance().currentPages.Count - 1);
                        }
                        if (MediaPlayer.GetInstance().currentPages.Contains("a") || MediaPlayer.GetInstance().currentPages.Contains("h")||  MediaPlayer.GetInstance().currentPages.Contains("m"))
                        {
                            if(!media.currentPages.Contains("artistMenu")) { media.currentPages.Add("artistMenu"); }
                            input = ArtistPage();
                        }
                        else { input = LocaleHomePage(); }
                        break;
                    case "albumMenu":
                        if (MediaPlayer.GetInstance().currentPages.Count > 3)
                        {
                            MediaPlayer.GetInstance().currentPages.RemoveAt(MediaPlayer.GetInstance().currentPages.Count - 1);
                        }
                        if (MediaPlayer.GetInstance().currentPages.Contains("a") || MediaPlayer.GetInstance().currentPages.Contains("l") || MediaPlayer.GetInstance().currentPages.Contains("artistMenu"))
                        {
                            media.currentPages.Add("albumMenu");
                            input = AlbumPage();
                        }
                        else { input = LocaleHomePage(); }
                        break;
                    case "playlistMenu":
                        if (MediaPlayer.GetInstance().currentPages.Count > 2)
                        {
                            MediaPlayer.GetInstance().currentPages.RemoveAt(MediaPlayer.GetInstance().currentPages.Count - 1);
                        }
                        if (MediaPlayer.GetInstance().currentPages.Contains("p"))
                        {
                            media.currentPages.Add("playlistMenu");
                            input = LocaleHomePage();
                        }
                        else { input = LocaleHomePage(); }
                        break;

                    case "i": //Discografia
                        if (MediaPlayer.GetInstance().currentPages.Count > 3)
                        {
                            MediaPlayer.GetInstance().currentPages.RemoveAt(MediaPlayer.GetInstance().currentPages.Count - 1);
                        }
                        if (MediaPlayer.GetInstance().currentPages.Contains("a") || MediaPlayer.GetInstance().currentPages.Contains("artistMenu"))
                        {
                            media.currentPages.Add("i");
                            input = Discography();
                        }
                        else { input = LocaleHomePage(); }
                        break;

                    case "a":  //Artisti
                        if (MediaPlayer.GetInstance().currentPages.Count > 1)
                        {
                            //MediaPlayer.GetInstance().currentPages.RemoveAt(MediaPlayer.GetInstance().currentPages.Count - 1);
                            media.currentPages.Clear();
                            media.currentPages.Add("m");
                        }
                        if (MediaPlayer.GetInstance().currentPages.Contains("m"))
                        {
                            media.currentPages.Add("a");
                            input = LocaleAllArtists();
                        }
                        else { input = LocaleHomePage(); }
                        break;
                    case "l": //Album
                        if (MediaPlayer.GetInstance().currentPages.Count > 1)
                        {
                            //MediaPlayer.GetInstance().currentPages.RemoveAt(MediaPlayer.GetInstance().currentPages.Count - 1);
                            media.currentPages.Clear();
                            media.currentPages.Add("m");
                        }
                        if (MediaPlayer.GetInstance().currentPages.Contains("m"))
                        {
                            media.currentPages.Add("l");
                            input = LocaleAllAlbums();
                        }
                        else { input = LocaleHomePage(); }
                        break;
                    case "r": //RADIOS
                        if (MediaPlayer.GetInstance().currentPages.Count > 1)
                        {
                            //MediaPlayer.GetInstance().currentPages.RemoveAt(MediaPlayer.GetInstance().currentPages.Count - 1);
                            media.currentPages.Clear();
                            media.currentPages.Add("m");
                        }
                        if (MediaPlayer.GetInstance().currentPages.Contains("m"))
                        {
                            media.currentPages.Add("r");
                            input = LocaleAllRadios();
                        }
                        else { input = LocaleHomePage(); }
                        break;
                    case "f": //SEARCH
                        if (MediaPlayer.GetInstance().currentPages.Count > 1)
                        {
                            //MediaPlayer.GetInstance().currentPages.RemoveAt(MediaPlayer.GetInstance().currentPages.Count - 1);
                            media.currentPages.Clear();
                            media.currentPages.Add("m");
                        }
                        if (MediaPlayer.GetInstance().currentPages.Contains("m"))
                        {
                            media.currentPages.Add("f");
                            input = Search();
                        }
                        else { input = LocaleHomePage(); }
                        break;
                    case "p": //Playlists
                        if (MediaPlayer.GetInstance().currentPages.Count > 1)
                        {
                            //MediaPlayer.GetInstance().currentPages.RemoveAt(MediaPlayer.GetInstance().currentPages.Count - 1);
                            media.currentPages.Clear();
                            media.currentPages.Add("m");
                        }
                        if (MediaPlayer.GetInstance().currentPages.Contains("m"))
                        {
                            media.currentPages.Add("p");
                            input = LocaleAllPlaylists();
                        }
                        else { input = LocaleHomePage(); }
                        break;
                    case "b": //Return
                        input = Return();
                        break;

                    default: //HomePage
                        media.currentPages.Clear();
                        media.currentPages.Add("h");
                        input = LocaleHomePage();
                        break;
                }
            } while (input != "q");
        }
        public static void LocaleNavbar()
        {
            Console.Clear();
            string local = Authentication.dataSource== "onlineSettings" ? "" : "local";
            Console.WriteLine($"SPOTIFY {local}\n\n");
            if (MediaPlayer.GetInstance().currentPages.Contains("h"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Home");
                Console.ResetColor();
                Console.WriteLine("   Music   Settings");
            }
            else if (MediaPlayer.GetInstance().currentPages.Contains("m"))
            {
                Console.Write("Home   ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Music");
                Console.ResetColor();
                Console.WriteLine("   Settings");
                MusicSubNavbar();

            }
            else if (MediaPlayer.GetInstance().currentPages.Contains("o"))
            {
                Console.Write("Home   Music");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("   Settings");
                Console.ResetColor();
                SettingsSubNavbar();
            }

        }
        public static string MusicSubNavbar()
        {
            string input = "";

            // AllSongs Artisti Album Radio Ricerca
            if (MediaPlayer.GetInstance().currentPages.Count == 1)
            {
                Console.WriteLine("Tutte le canzoni  Artisti  Album  Radio   Playlists  Ricerca\n");
            }
            else if (MediaPlayer.GetInstance().currentPages.Contains("s"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Tutte le canzoni");
                Console.ResetColor();
                Console.WriteLine("  Artisti  Album  Radio   Playlists  Ricerca\n");
            }
            else if (MediaPlayer.GetInstance().currentPages.Contains("a"))
            {
                Console.Write("Tutte le canzoni");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("  Artisti");
                Console.ResetColor();
                Console.WriteLine("  Album  Radio   Playlists  Ricerca\n");
            }
            else if (MediaPlayer.GetInstance().currentPages.Contains("l"))
            {
                Console.Write("Tutte le canzoni   Artisti");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("  Album");
                Console.ResetColor();
                Console.WriteLine("   Radio   Playlists  Ricerca\n");
            }
            else if (MediaPlayer.GetInstance().currentPages.Contains("r"))
            {
                Console.Write("Tutte le canzoni   Artisti   Album");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("   Radio");
                Console.ResetColor();
                Console.WriteLine("   Playlists  Ricerca\n");
            }
            else if (MediaPlayer.GetInstance().currentPages.Contains("p"))
            {
                Console.Write("Tutte le canzoni   Artisti   Album   Radio");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("  Playlists");
                Console.ResetColor();
                Console.Write("  Ricerca");
                Console.WriteLine("\n");
            }
            else if (MediaPlayer.GetInstance().currentPages.Contains("f"))
            {
                Console.Write("Tutte le canzoni   Artisti   Album   Radio   Playlists");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("  Ricerca");
                Console.ResetColor();
                Console.WriteLine("\n");
            }


            return input;
        }
        public static string SettingsSubNavbar()
        {
            string input = "";
            if (Authentication.dataSource == "onlineSettings")
            {
                if (MediaPlayer.GetInstance().currentPages.Contains("e"))
                {
                    Console.Write("Profilo   Social   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Audio\n");
                    Console.ResetColor();
                }
                else if (MediaPlayer.GetInstance().currentPages.Contains("u"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Profilo");
                    Console.ResetColor();
                    Console.WriteLine("   Social   Audio\n");

                }
                else if (MediaPlayer.GetInstance().currentPages.Contains("c"))
                {
                    Console.Write("Profilo   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Social");
                    Console.ResetColor();
                    Console.WriteLine("   Audio\n");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Audio\n");
                Console.ResetColor();
            }

            return input;
        }

        public static string LocaleHomePage()
        {
            LocaleNavbar();

            string input;
            Console.WriteLine("I top 5 artisti del momento");
            var artists = Utility.GetTopFiveArtists();
            for (int i = 0; i < artists.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {artists[i].Title}");
            }
            SongPlayer();
            input = Console.ReadLine();
            try
            {
                if (int.Parse(input) >= 1 && int.Parse(input) <= artists.Count())
                {

                    MediaPlayer.GetInstance().currentArtist = Utility.FindArtist(artists[int.Parse(input) - 1].Title);

                    return "artistMenu";
                }
            }
            catch { return input; }
            return input;
        }
        public static string LocaleAllSongs(List<Song> songs = null)
        {
            int flag = 1;
            if (songs == null)
            {
                songs = DataStore.GetInstance().songs;
                flag = 0;
            }
            int pageNumber = 0;
            int pagination = 9;
            string input;
            do
            {
                LocaleNavbar();
                var songsToPrint = GetPage(songs, pageNumber, pagination);
                for (int j = 0; j < songsToPrint.Count; j++)
                {
                    Console.WriteLine($"{j + 1}. {songsToPrint[j].Title}");
                }
                Console.WriteLine("0. Next page");
                Console.WriteLine("H. Torna alla homepage");
                SongPlayer();
                input = Console.ReadLine().ToLower();
                try
                {
                    if (input == "0")
                    {
                        if (pageNumber >= songs.Count / pagination)
                        {
                            pageNumber = 0;
                        }
                        else { pageNumber++; }
                    }
                    else if (input == "h")
                    {
                        return input;
                    }
                    else if (int.Parse(input) >= 1 && int.Parse(input) <= songsToPrint.Count)
                    {
                        MediaPlayer.GetInstance().Play(Utility.FindSong(songsToPrint[int.Parse(input) - 1].Title));
                        MediaPlayer.GetInstance().SetStatus(Status.ALL);
                        if (flag == 0) { return "s"; }
                        else { return "f"; }

                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    continue;
                }
                catch { return input; }

            } while (true);
        }
        public static string LocaleAllArtists(List<Artist> artists = null)
        {
            if (artists == null)
            {
                artists = DataStore.GetInstance().artists;
            }
            int pageNumber = 0;
            int pagination = 9;
            string input;
            do
            {
                Console.Clear();
                LocaleNavbar();
                var artistsToPrint = GetPage(artists, pageNumber, pagination);
                for (int j = 0; j < artistsToPrint.Count; j++)
                {
                    Console.WriteLine($"{j + 1}. {artistsToPrint[j].Title}");
                }
                Console.WriteLine("\n0. Next page");
                Console.WriteLine("H. Torna alla homepage");
                SongPlayer();
                input = Console.ReadLine().ToLower();
                try
                {
                    if (input == "0")
                    {
                        if (pageNumber >= artists.Count / pagination)
                        {
                            pageNumber = 0;
                        }
                        else { pageNumber++; }
                    }
                    else if (input == "h")
                    {
                        return input;
                    }
                    else if (int.Parse(input) >= 1 && int.Parse(input) <= artistsToPrint.Count)
                    {

                        MediaPlayer.GetInstance().currentArtist = Utility.FindArtist(artistsToPrint[int.Parse(input) - 1].Title);
                        MediaPlayer.GetInstance().currentPages.Clear();
                        MediaPlayer.GetInstance().currentPages.Add("m");
                        MediaPlayer.GetInstance().currentPages.Add("a");
                        return "artistMenu";
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    continue;
                }
                catch { return input; }
            } while (true);
        }
        public static string LocaleAllAlbums(List<Album> albums = null)
        {
            if (albums == null)
            {
                albums = DataStore.GetInstance().albums;
            }
            int pageNumber = 0;
            int pagination = 9;
            string input;
            do
            {
                LocaleNavbar();
                Console.WriteLine("Tutti gli album:\n");
                var songsToPrint = GetPage(albums, pageNumber, pagination);
                for (int j = 0; j < songsToPrint.Count; j++)
                {
                    Console.WriteLine($"{j + 1}. {songsToPrint[j].Title}");
                }
                Console.WriteLine("\n0. Next page");
                Console.WriteLine("H. Torna alla homepage");
                SongPlayer();
                input = Console.ReadLine().ToLower();
                try
                {
                    if (input == "0")
                    {
                        if (pageNumber >= albums.Count / pagination)
                        {
                            pageNumber = 0;
                        }
                        else { pageNumber++; }
                    }
                    else if (input == "h")
                    {
                        return input;
                    }
                    else if (int.Parse(input) >= 1 && int.Parse(input) <= songsToPrint.Count)
                    {
                        MediaPlayer.GetInstance().currentAlbum = Utility.FindAlbum(songsToPrint[int.Parse(input) - 1].Title);
                        MediaPlayer.GetInstance().currentPages.Clear();
                        MediaPlayer.GetInstance().currentPages.Add("m");
                        MediaPlayer.GetInstance().currentPages.Add("l");
                        return "albumMenu";
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    continue;
                }
                catch { return input; }

            } while (true);
        }
        public static string LocaleAllRadios()
        {
            var radios = DataStore.GetInstance().radios.OrderBy(x => x.Genre.Title).ToList();
            int pageNumber = 0;
            int pagination = 9;
            string input;
            do
            {
                Console.Clear();
                LocaleNavbar();
                var songsToPrint = GetPage(radios, pageNumber, pagination);
                for (int j = 0; j < songsToPrint.Count; j++)
                {
                    Console.WriteLine($"{j + 1}. {songsToPrint[j].Title}");
                }
                Console.WriteLine("\n0. Next page");
                Console.WriteLine("H. Torna alla homepage");
                SongPlayer();
                input = Console.ReadLine().ToLower();
                try
                {
                    if (input == "0")
                    {
                        if (pageNumber >= radios.Count / pagination)
                        {
                            pageNumber = 0;
                        }
                        else { pageNumber++; }
                    }
                    else if (input == "h")
                    {
                        return input;
                    }
                    else if (int.Parse(input) >= 1 && int.Parse(input) <= songsToPrint.Count)
                    {
                        MediaPlayer.GetInstance().currentRadio = Utility.FindRadio(songsToPrint[int.Parse(input) - 1].Title);
                        MediaPlayer.GetInstance().PlayRadio();
                        return "r";
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    continue;
                }
                catch { return input; }
            } while (true);
        }
        public static string LocaleAllPlaylists()
        {
            var radios = DataStore.GetInstance().playlists;
            int pageNumber = 0;
            int pagination = 9;
            string input;
            do
            {
                Console.Clear();
                LocaleNavbar();
                var songsToPrint = GetPage(radios, pageNumber, pagination);
                for (int j = 0; j < songsToPrint.Count; j++)
                {
                    Console.WriteLine($"{j + 1}. {songsToPrint[j].Title}");
                }
                Console.WriteLine("\n0. Next page");
                Console.WriteLine("H. Torna alla homepage");
                SongPlayer();
                input = Console.ReadLine().ToLower();
                try
                {
                    if (input == "0")
                    {
                        if (pageNumber >= radios.Count / pagination)
                        {
                            pageNumber = 0;
                        }
                        else { pageNumber++; }
                    }
                    else if (input == "h")
                    {
                        return input;
                    }
                    else if (int.Parse(input) >= 1 && int.Parse(input) <= songsToPrint.Count)
                    {

                        MediaPlayer.GetInstance().currentPlaylist = Utility.FindPlaylist(songsToPrint[int.Parse(input) - 1].Title);
                        return "playlistMenu";
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    continue;
                }
                catch { return input; }
            } while (true);
        }
        public static string ArtistPage()
        {
            string input;
            do
            {
                Artist artist = MediaPlayer.GetInstance().currentArtist;
                LocaleNavbar();
                Console.WriteLine($"\n{artist.Title}\n");
                var topSongs = Utility.GetTopFiveSongs();
                int j = 1;
                Console.WriteLine("Le canzoni più ascoltate");
                foreach (var s in topSongs)
                {
                    Console.WriteLine($"{j}.{s.Title} Ascolti: {s.Popularity}");
                    j++;
                }
                CreateDivisor();
                Console.WriteLine("\nDiscografia:\n");
                for (int i = 0; i < 4 && i < artist.Albums.Count; i++)
                {
                    Console.WriteLine($"{j}. {artist.Albums[i].Title} ");
                    j++;
                }
                Console.WriteLine("\nPremi i per visualizzare tutta la discografia");
                SongPlayer();
                input = Console.ReadLine();
                try
                {
                    if (int.Parse(input) >= 1 && int.Parse(input) <= topSongs.Count)
                    {
                        MediaPlayer.GetInstance().Play(Utility.FindSong(topSongs[int.Parse(input) - 1].Title));
                        MediaPlayer.GetInstance().SetStatus(Status.TOP);
                        return "artistMenu";
                    }
                    else if (int.Parse(input) > topSongs.Count && int.Parse(input) <= 8)
                    {
                        MediaPlayer.GetInstance().currentAlbum = Utility.FindAlbum(artist.Albums[int.Parse(input) - topSongs.Count -1].Title);
                        return "albumMenu";
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    continue;
                }
                catch { return input; }
            } while (true);
        }
        public static string AlbumPage()
        {
            Album album = MediaPlayer.GetInstance().currentAlbum;
            string input;
            int pageNumber = 0;
            int pagination = 9;
            do
            {
                LocaleNavbar();
                Console.WriteLine($"{album.Title}\n");

                var songsToPrint = GetPage(album.Songs, pageNumber, pagination);
                for (int j = 0; j < songsToPrint.Count; j++)
                {
                    Console.WriteLine($"{j + 1}. {songsToPrint[j].Title}");
                }
                Console.WriteLine("0. Next page");
                Console.WriteLine("H. Torna alla homepage");
                SongPlayer();
                input = Console.ReadLine().ToLower();
                try
                {
                    if (input == "0")
                    {
                        if (pageNumber >= album.Songs.Count / pagination)
                        {
                            pageNumber = 0;
                        }
                        else { pageNumber++; }
                    }
                    else if (input == "h")
                    {
                        return input;
                    }
                    else if (int.Parse(input) >= 1 && int.Parse(input) <= songsToPrint.Count)
                    {
                        MediaPlayer.GetInstance().Play(Utility.FindSong(songsToPrint[int.Parse(input) - 1].Title));
                        MediaPlayer.GetInstance().SetStatus(Status.ALBUM);
                        return "albumMenu";
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    continue;
                }
                catch
                {
                    return input;
                }
            } while (true);
        }
        //public static string PlaylistPage()
        //{
        //    var playlist = MediaPlayer.GetInstance().currentPlaylist;
        //    string input;
        //    int pageNumber = 0;
        //    int pagination = 9;
        //    do
        //    {
        //        LocaleNavbar();
        //        Console.WriteLine($"{playlist.Title}\n");

        //        var songsToPrint = GetPage(playlist.getSongs(), pageNumber, pagination);
        //        for (int j = 0; j < songsToPrint.Count; j++)
        //        {
        //            Console.WriteLine($"{j + 1}. {songsToPrint[j].Title}");
        //        }
        //        Console.WriteLine("0. Next page");
        //        Console.WriteLine("H. Torna alla homepage");
        //        Console.WriteLine("+. Aggiungi brano a playlist");
        //        SongPlayer();
        //        input = Console.ReadLine().ToLower();
        //        try
        //        {
        //            if (input == "0")
        //            {
        //                if (pageNumber >= playlist.getSongs().Count / pagination)
        //                {
        //                    pageNumber = 0;
        //                }
        //                else { pageNumber++; }
        //            }
        //            else if (input == "h")
        //            {
        //                return input;
        //            }
        //            else if (input == "+")
        //            {
        //                input = Search("p");
        //            }
        //            else if (int.Parse(input) >= 1 && int.Parse(input) <= songsToPrint.Count)
        //            {
        //                MediaPlayer.GetInstance().Play(Utility.FindSong(songsToPrint[int.Parse(input) - 1].Title));
        //                MediaPlayer.GetInstance().currentSong.SetStatus(Status.PLAYLIST);
        //                return "playlistMenu";
        //            }
        //        }
        //        catch (ArgumentOutOfRangeException)
        //        {
        //            continue;
        //        }
        //        catch
        //        {
        //            return input;
        //        }
        //    } while (true);




        //}
        public static string Discography()
        {
            var albums = MediaPlayer.GetInstance().currentArtist.Albums;
            int pageNumber = 0;
            int pagination = 9;
            string input;
            do
            {

                LocaleNavbar();
                Console.WriteLine($"Discografia di {MediaPlayer.GetInstance().currentArtist.Title}:\n");
                var songsToPrint = GetPage(albums, pageNumber, pagination);
                for (int j = 0; j < songsToPrint.Count; j++)
                {
                    Console.WriteLine($"{j + 1}. {songsToPrint[j].Title}");
                }
                Console.WriteLine("\n0. Next page");
                Console.WriteLine("H. Torna alla homepage");
                SongPlayer();
                input = Console.ReadLine().ToLower();
                try
                {
                    if (input == "0")
                    {
                        if (pageNumber >= albums.Count / pagination)
                        {
                            pageNumber = 0;
                        }
                        else { pageNumber++; }
                    }
                    else if (input == "h")
                    {
                        return input;
                    }
                    else if (int.Parse(input) >= 1 && int.Parse(input) <= songsToPrint.Count)
                    {
                        MediaPlayer.GetInstance().currentAlbum = Utility.FindAlbum(songsToPrint[int.Parse(input) - 1].Title);
                        return "albumMenu";
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    continue;
                }
                catch { return input; }

            } while (true);







        }
        public static string Search(string SearchType = "")
        {
            LocaleNavbar();
            string input = "f";
            List<Song> songs = new();
            List<Album> albums = new();
            List<Artist> artists = new();



            if (SearchType == "")
            {
                do
                {
                    LocaleNavbar();
                    Console.WriteLine("Cosa vuoi cercare?\n1.Canzoni\n2.Album\n3.Artisti\n");
                    SongPlayer();
                    input = Console.ReadLine();
                } while (input != "1" && input != "2" && input != "3" && input != "b" && input != "h");

                if (input == "1") { SearchType = "s"; }

                else if (input == "2") { SearchType = "l"; }

                else if (input == "3") { SearchType = "a"; }

            }
            LocaleNavbar();


            if (SearchType == "s")
            {
                Console.WriteLine("Che canzone cerchi?\n");
                SongPlayer();
                input = Console.ReadLine().ToLower();
                foreach (var song in DataStore.dataStore.songs)
                {
                    if (song.Title.ToLower() == input)
                    {
                        songs.Add(song);
                    }
                }
                if (songs.Count != 0)
                {
                    return LocaleAllSongs(songs);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCanzone non trovata");
                    Console.ResetColor();
                    Console.ReadLine();
                    return "";
                }
            }
            else if (SearchType == "l")
            {
                Console.WriteLine("Che album cerchi?\n");
                SongPlayer();
                input = Console.ReadLine().ToLower();
                foreach (var album in DataStore.dataStore.albums)
                {
                    if (album.Title.ToLower() == input)
                    {
                        albums.Add(album);
                        Console.WriteLine(album.Title);
                    }
                }
                if (albums.Count != 0)
                {
                    return LocaleAllAlbums(albums);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nAlbum non trovato");
                    Console.ResetColor();
                    Console.ReadLine();
                    return "f";
                }

            }
            else if (SearchType == "a")
            {
                Console.WriteLine("Che artista cerchi?\n");
                SongPlayer();
                input = Console.ReadLine().ToLower();
                foreach (var artist in DataStore.dataStore.artists)
                {
                    if (artist.Title.ToLower() == input)
                    {
                        artists.Add(artist);
                        Console.WriteLine(artist.Title);
                    }
                }
                if (artists.Count != 0)
                {
                    return LocaleAllArtists(artists);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nArtista non trovato");
                    Console.ResetColor();
                    Console.ReadLine();
                    return "f";
                }

            }
            //else if (SearchType == "p")
            //{
            //    int pageNumber = 0;
            //    int pagination = 9;
            //    Console.WriteLine("Che canzone vuoi aggiungere?\n");
            //    SongPlayer();
            //    input = Console.ReadLine().ToLower();
            //    foreach (var song in DataStore.dataStore.songs)
            //    {
            //        if (song.Title.ToLower() == input)
            //        {
            //            songs.Add(song);
            //        }
            //    }
            //    if (songs.Count != 0)
            //    {
            //        do
            //        {
            //            LocaleNavbar();
            //            var songsToPrint = GetPage(songs, pageNumber, pagination);
            //            for (int j = 0; j < songsToPrint.Count; j++)
            //            {
            //                Console.WriteLine($"{j + 1}. {songsToPrint[j].Title}");
            //            }
            //            Console.WriteLine("0. Next page");
            //            Console.WriteLine("H. Torna alla homepage");
            //            SongPlayer();
            //            input = Console.ReadLine().ToLower();
            //            try
            //            {
            //                if (input == "0")
            //                {
            //                    if (pageNumber >= songs.Count / pagination)
            //                    {
            //                        pageNumber = 0;
            //                    }
            //                    else { pageNumber++; }
            //                }
            //                else if (input == "h")
            //                {
            //                    return input;
            //                }
            //                else if (int.Parse(input) >= 1 && int.Parse(input) <= songsToPrint.Count)
            //                {

            //                    MediaPlayer.GetInstance().currentPlaylist.AddSong(Utility.FindSong(songsToPrint[int.Parse(input) - 1].Title));
            //                    return "playlistMenu";
            //                }
            //            }
            //            catch (ArgumentOutOfRangeException)
            //            {
            //                continue;
            //            }
            //            catch { return input; }

            //        } while (true);
            //    }
            //    else
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.WriteLine("\nCanzone non trovata");
            //        Console.ResetColor();
            //        Console.ReadLine();
            //        return "f";
            //    }


            //}
            return input;
        }
        public static string AudioPage()
        {

            string input;
            do
            {
                LocaleNavbar();
                Console.WriteLine("\nEqualizzazione:\n");
                Console.WriteLine($"1.Volume: {Equalization.Volume}\n2.Bassi: {Equalization.Bass}\n3.Alti: {Equalization.Pitch}");
                input = Console.ReadLine();
                if (input == "1")
                {
                    Equalization.IncreaseVolume();
                }
                if (input == "2")
                {
                    Equalization.IncreaseBass();
                }
                if (input == "3")
                {
                    Equalization.IncreasePitch();
                }
            } while (input != "h" && input != "u" && input != "c" && input != "m");
            return input;
        }
        public static string ProfilePage()
        {
            string input;
            do
            {
                LocaleNavbar();
                Console.WriteLine("\nModifica Profilo:\n");
                input = Console.ReadLine();
            } while (input != "h" && input != "e" && input != "c" && input != "m");
            return input;
        }
        public static string SocialPage()
        {
            string input;
            do
            {
                LocaleNavbar();
                Console.WriteLine("\nConnessione a Social:\n");
                input = Console.ReadLine();
            } while (input != "h" && input != "u" && input != "e" && input != "m");
            return input;
        }
        public static void SongPlayer()
        {
            Console.WriteLine("\n\n");


            if (MediaPlayer.GetInstance().currentSong != null)
            {
                CreateDivisor();

                if (MediaPlayer.GetInstance().isPlaying)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"In riproduzione: {MediaPlayer.GetInstance().currentSong.Title} di {MediaPlayer.GetInstance().currentSong.Artist.Title}");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"In pausa: {MediaPlayer.GetInstance().currentSong.Title} di {MediaPlayer.GetInstance().currentSong.Artist.Title}");
                }
            }
            Console.ResetColor();
        }


        public static string Return()
        {
            try
            {
                MediaPlayer.GetInstance().currentPages.RemoveAt(MediaPlayer.GetInstance().currentPages.Count - 1);
                var page = MediaPlayer.GetInstance().currentPages[MediaPlayer.GetInstance().currentPages.Count - 1];
                return page;
            }
            catch
            {
                return "h";
            }
        }
        public static IList<T> GetPage<T>(IList<T> list, int page, int pageSize)
        {
            return list.Skip(page * pageSize).Take(pageSize).ToList();
        }
        public static void CreateDivisor()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n--------------------------------------------------------\n");
            Console.ResetColor();
        }
    }
}
