using System;
using System.Media;

namespace TheGameProject
{
    public class BackgroundMusic
    {
        private static BackgroundMusic _instance;
        private SoundPlayer _player;
        private bool isPlaying; // Flag to track if music is playing

        private BackgroundMusic()
        {
            _player = new SoundPlayer(Properties.Resources.gameBG); // Replace with your resource name
            isPlaying = false;
        }

        public static BackgroundMusic Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BackgroundMusic();
                return _instance;
            }
        }

        public void Play()
        {
            if (!isPlaying) // Only play if not already playing
            {
                _player.PlayLooping();
                isPlaying = true;
            }
        }

        public void Stop()
        {
            if (isPlaying) // Only stop if currently playing
            {
                _player.Stop();
                isPlaying = false;
            }
        }
    }
}
