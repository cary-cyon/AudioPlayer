using AudioPlayer2.Model;

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
        public void PlayAudio(object obj)
        {
            var audio = obj as Audio;
            if (audio != null)
            {
                pleyer = new LocalPlayer( new LocalSource(audio.FilePath));
                pleyer.Play();
            }
        }
        
    }
}
