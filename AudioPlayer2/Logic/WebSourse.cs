using AudioPlayer2.Logic.Interfaces;
using System;

namespace AudioPlayer2.Logic
{
    internal class WebSourse : IAudioSource
    {
        private static string webPass = "http://localhost:8181/audio?title=";
        private string trackTitle;
        public WebSourse(string tille)
        {
            trackTitle = tille;
        }
        public Uri GetPlayable()
        {
            return new Uri(webPass + trackTitle, UriKind.Absolute);
        }
    }
}