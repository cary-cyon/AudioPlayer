using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer2.Logic.Interfaces
{
    internal interface IAudioPlayer
    {
        void Play();
        void Pause();
        void GoTo();
        IAudioSource AudioSource { get; set; }
    }
}
