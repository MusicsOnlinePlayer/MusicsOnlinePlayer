using System;
using Utility.Musics;

namespace Musics___Client.API.Events
{
    public class PathClickedEventArgs : EventArgs
    {
        public string Name { get; set; }
        public ElementType type;

        public PathClickedEventArgs(string name, ElementType type)
        {
            Name = name;
            this.type = type;
        }
    }
}
