using AudioPlayer2.Logic.Interfaces;
using System;

namespace AudioPlayer2.Logic
{
    internal class LocalSource : IAudioSource
    {
        private string audioFile;
        public LocalSource(string filePath)
        {
            audioFile = filePath;
        }
        public Uri GetPlayable()
        {
            return new Uri(audioFile, UriKind.Relative);
        }
    }
}
