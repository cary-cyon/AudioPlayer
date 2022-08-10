using AudioPlayer2.Logic.Interfaces;
using NAudio.Wave;
using System;

namespace AudioPlayer2.Logic
{
    internal class LocalPlayer : IAudioPlayer
    {
        private WaveOutEvent outputDevice;
        public IAudioSource AudioSource { get; set; }
        public LocalPlayer(IAudioSource audioSource) 
        { 
            AudioSource = audioSource;
            outputDevice = new WaveOutEvent();
        }

        public void GoTo()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            outputDevice?.Pause();
        }

        public void Play()
        {
            var audio = AudioSource.GetPlayable();
            outputDevice.Init(audio);
            outputDevice.Play();
        }
        ~LocalPlayer()
        {
            outputDevice.Dispose();
        }
    }
}
