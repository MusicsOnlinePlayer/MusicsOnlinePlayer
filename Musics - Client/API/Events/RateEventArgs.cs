using System;
using Utility.Musics;

namespace Musics___Client.API.Events
{
    public class RateEventArgs : EventArgs
    {
        public string ElementRatedMID { get; set; }
        public ElementType Type { get; set; }

        public RateEventArgs(string elementRatedMID, ElementType type)
        {
            ElementRatedMID = elementRatedMID;
            Type = type;
        }
    }
}
