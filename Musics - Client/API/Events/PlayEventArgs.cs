using System;
using Utility.Musics;

namespace Musics___Client.API.Events
{
    public class PlayEventArgs : EventArgs
    {
        public IElement Selected { get; set; }

        public PlayEventArgs(IElement element)
        {
            Selected = element;
        }
    }
}
