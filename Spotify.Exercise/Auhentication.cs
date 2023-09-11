using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Exercise
{
    public static class Authentication
    {

        public static string dataSource;
       
        
        public static void SourceSelection(string choice)
        {
            if (choice == "l")
            {                
                dataSource= "localSettings";    
            }
            else
            {                
                dataSource= "onlineSettings";
            }
        }
    }
}
