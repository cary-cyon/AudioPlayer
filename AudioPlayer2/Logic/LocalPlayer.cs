using AudioPlayer2.Logic.Interfaces;
using System;
using System.Windows;
using System.Windows.Media;

namespace AudioPlayer2.Logic
{
    internal class LocalPlayer : IAudioPlayer
    {

        private MediaPlayer outputDevice;
        public IAudioSource _audioSource;
        public Action<Duration> SetDuration { get; set; }
        public IAudioSource AudioSource {
            get {return _audioSource;}
            set { _audioSource = value; outputDevice.Open(new Uri(_audioSource.GetPlayable(), UriKind.Relative)); }
        }
        public LocalPlayer() 
        { 
            outputDevice = new MediaPlayer();
            outputDevice.MediaOpened += OutputDevice_MediaOpened;
        }

        private void OutputDevice_MediaOpened(object? sender, EventArgs e)
        {
            var duration = outputDevice.NaturalDuration;
            SetDuration(duration);
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
        public Duration Duration
        {
            get { return outputDevice.NaturalDuration; }
        }
    }
}
