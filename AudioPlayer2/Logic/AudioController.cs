using AudioPlayer2.Model;
using System;
using System.Windows;

namespace AudioPlayer2.Logic
{
    //TODO что-то состоятельное 
    internal class AudioController
    {
        private LocalPlayer pleyer;

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
        }
        public void PlayAudio(object obj)
        {
            pleyer.Play();
        }
        public void GoTo(object obj)
        {
            double SliderValue = (double)obj;
            pleyer.GoTo(SliderValue);
        }
        public AudioController()
        {
            pleyer = new LocalPlayer();
        }
        
    }
}
