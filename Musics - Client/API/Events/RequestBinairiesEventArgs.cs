using System;
using Utility.Musics;

namespace Musics___Client.API.Events
{
    public class RequestBinairiesEventArgs : EventArgs
    {
        public RequestBinairiesEventArgs(Music requestedMusic)
        {
            RequestedMusic = requestedMusic;
        }

        public Music RequestedMusic { get; set; }
    }
}
