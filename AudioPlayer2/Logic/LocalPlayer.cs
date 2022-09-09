using AudioPlayer2.Logic.Interfaces;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace AudioPlayer2.Logic
{
    internal class LocalPlayer : IAudioPlayer
    {

        private MediaPlayer outputDevice;
        private DispatcherTimer dispatcherTimer;
        public IAudioSource _audioSource;
        public Action<Duration> SetDuration { get; set; }
        public Action IncreasePositionByOneSec { get; set; } 
        public IAudioSource AudioSource {
            get {return _audioSource;}
            set { _audioSource = value; outputDevice.Open(new Uri(_audioSource.GetPlayable(), UriKind.Relative)); }
        }
        public LocalPlayer() 
        { 
            outputDevice = new MediaPlayer();
            outputDevice.MediaOpened += OutputDevice_MediaOpened;
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
        }
        //NaturalDuration can't be get bеfor MediaOpened
        //This method use delegat from ApplicationViewModel for set it
        private void OutputDevice_MediaOpened(object? sender, EventArgs e)
        {
            SetDuration(outputDevice.NaturalDuration);
        }

        public void GoTo(double SliderPosition)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, (int)SliderPosition);
            outputDevice.Position = ts;
        }
        //Pause track
        public void Pause()
        {
            outputDevice?.Pause();
            dispatcherTimer?.Stop();
        }
        //Stop track. Can't be continue.
        public void Stop()
        {
            outputDevice.Stop();
            dispatcherTimer?.Stop();
        }
        //Method start playing Audio. Starts from initial track
        public void Play()
        {
            var audio = AudioSource.GetPlayable();
            outputDevice.Open(new Uri(audio, UriKind.Relative));
            outputDevice.Play();
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object? sender, EventArgs e)
        {
            IncreasePositionByOneSec();
        }

        public void GoTo()
        {
            throw new NotImplementedException();
        }
    }
}
