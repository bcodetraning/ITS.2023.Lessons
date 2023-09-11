using Spotify.Exercise;
using System;

namespace Spotify.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserInterface.SourceSelectionInterface();

            UserInterface.Router("h");
            Console.ReadLine();
        }
    }
    
}
