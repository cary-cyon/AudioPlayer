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
            if(pleyer != null)
                pleyer.Stop();
        }
        public void PlayAudio(object obj)
        {
            var audio = obj as Audio;
            if (audio != null)
            {
                pleyer.AudioSource = new LocalSource(audio.FilePath);
                pleyer.Play();
            }
        }
        public Duration GetDuration()
        {
            return pleyer.Duration;
        }
        //TODO
        public void GoTo(object obj)
        {
            //TODO
            // obj is 
            double SliderValue = (double)obj;
            pleyer.GoTo();
        }
        public AudioController()
        {
            pleyer = new LocalPlayer();
        }
        
    }
}
