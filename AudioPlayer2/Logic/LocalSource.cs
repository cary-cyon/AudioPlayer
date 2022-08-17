using AudioPlayer2.Logic.Interfaces;

namespace AudioPlayer2.Logic
{
    internal class LocalSource : IAudioSource
    {
        private string audioFile;
        public LocalSource(string filePath)
        {
            audioFile = filePath;
        }
        public string GetPlayable()
        {
            return audioFile;
        }
    }
}
