namespace StreamingPlayer
{
    interface IPlayer
    {
        public void Play(int SongId); 
        public void ShowPlaying();
        public void StartPlaying();
        public void Stop();
        public void Pause();
        public void Rate();
        public void Forward();
        public void Backward();
        public void ListSongs();

    }
}
