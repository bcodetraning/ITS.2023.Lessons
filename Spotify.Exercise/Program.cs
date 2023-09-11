using System;
using Utility.Read;

namespace Spotify.Exercise
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
