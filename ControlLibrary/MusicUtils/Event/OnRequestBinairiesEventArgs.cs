using System;
using Utility.Musics;

namespace ControlLibrary.MusicUtils.Event
{
    public class OnRequestBinairiesEventArgs : EventArgs
    {
        public OnRequestBinairiesEventArgs(Utility.Musics.Music requestedMusic)
        {
            RequestedMusic = requestedMusic;
        }

        public Utility.Musics.Music RequestedMusic { get; set; }


    }
}
