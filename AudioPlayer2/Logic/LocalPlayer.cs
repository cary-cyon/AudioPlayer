using AudioPlayer2.Logic.Interfaces;
using System;
using System.Windows.Media;

namespace AudioPlayer2.Logic
{
    internal class LocalPlayer : IAudioPlayer
    {

        private MediaPlayer outputDevice;
        public IAudioSource AudioSource { get; set; }
        public LocalPlayer(IAudioSource audioSource) 
        { 
            AudioSource = audioSource;
            outputDevice = new MediaPlayer();
        }

        public void GoTo()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            outputDevice?.Pause();
        }
        public void Stop()
        {
            outputDevice.Stop();
        }

        public void Play()
        {
            var audio = AudioSource.GetPlayable();
            outputDevice.Open(new Uri(audio, UriKind.Relative));
            outputDevice.Play();
        }
    }
}
