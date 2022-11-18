using AudioPlayer2.Model;
using System;
using System.Windows;
using System.Windows.Threading;

namespace AudioPlayer2.Logic
{
    //TODO что-то состоятельное 
    internal class AudioController
    {
        private LocalPlayer pleyer;
        private readonly DispatcherTimer dispatcherTimer;
        private Action increasePositionByOneSecond;

        public void PauseAudio(object obj)
        {
            pleyer.Pause();
        }
        //Set delegate which can set Duration in ViewModel. Use in MediaOpen Event
        public void SetDurationControlToPlayer(Action<Duration> del)
        {
            pleyer.SetDuration = del;
        }
        public void SetSource(string filePath)
        {
            pleyer.AudioSource = new LocalSource(filePath);
        }
        public void StopAudio(object obj)
        {
            pleyer.Stop();
            dispatcherTimer?.Stop();
        }
        public void PlayAudio(object obj)
        {
            pleyer.Play();
            dispatcherTimer.Start();
        }
        public void GoTo(object obj)
        {
            double SliderValue = obj != null ? (double)obj : 0;
            pleyer.GoTo(SliderValue);
        }
        public AudioController()
        {
            pleyer = new LocalPlayer();
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
        }

        internal void SetPositionControlToPlayer(Action increasePositionByOneSecond)
        {
            this.increasePositionByOneSecond += increasePositionByOneSecond;
        }

        private void DispatcherTimer_Tick(object? sender, EventArgs e)
        {
            increasePositionByOneSecond();
        }
    }
}
