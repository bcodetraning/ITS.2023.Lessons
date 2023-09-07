namespace StreamingPlayer
{
    public sealed class Netflix : StreamingPlatform
    {
        public Netflix()
        {
           
            files = new NetflixVideo[] {
                new NetflixVideo(){ title ="Titanic", Color = System.ConsoleColor.Blue},
                new NetflixVideo(){ title ="Terminator",Color = System.ConsoleColor.Cyan },
                new NetflixVideo(){ title ="Alien",Color = System.ConsoleColor.Green },
                new NetflixVideo(){ title ="Avatar",Color = System.ConsoleColor.Yellow}

                };

            totalTacks = files.Length;
        }
        private class NetflixVideo : Video
        {
            public NetflixVideo()
            {
            }
        }
    }
   
}
