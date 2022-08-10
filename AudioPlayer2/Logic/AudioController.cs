using AudioPlayer2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer2.Logic
{
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
