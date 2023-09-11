using System;
using System.Collections.Generic;



namespace Utility.Models
{
    public class Account
    {
        public Account()
        {
            Playlists = new List<Playlist>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Pw { get; set; }
        public string SubscriptionName { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual List<Playlist> Playlists { get; set; }
    }
}
