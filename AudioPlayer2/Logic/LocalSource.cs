using AudioPlayer2.Logic.Interfaces;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer2.Logic
{
    internal class LocalSource : IAudioSource
    {
        private AudioFileReader audioFile;
        public LocalSource(string filePath)
        {
            audioFile = new AudioFileReader(filePath);
        }
        public AudioFileReader GetPlayable()
        {
            return audioFile;
        }
        ~LocalSource()
        {
            audioFile.Dispose();
            audioFile = null;
        }
    }
}
