using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Exercise

{
    public static class Equalization
    {
        public static int Volume, Bass, Pitch = 0;

        public static void IncreaseVolume()
        {
            if (Volume < 10)
            {
                Volume++;
            }
            else { Volume = 0; }
        }
        public static void IncreaseBass()
        {
            if (Bass < 10)
            {
                Bass++;
            }
            else { Bass = 0; }
        }
        public static void IncreasePitch()
        {
            if (Pitch < 10)
            {
                Pitch++;
            }
            else { Pitch = 0; }
        }
    }

}
