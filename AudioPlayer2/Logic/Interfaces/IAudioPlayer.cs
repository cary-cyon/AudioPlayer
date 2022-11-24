using System;
using System.Windows;

namespace AudioPlayer2.Logic.Interfaces
{
    internal interface IAudioPlayer
    {
        void Play();
        void Stop();
        void Pause();
        void GoTo(double position);
        public Action<Duration> SetDuration { get; set; }
        IAudioSource AudioSource { get; set; }
    }
}
