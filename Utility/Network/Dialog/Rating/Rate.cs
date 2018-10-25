using System;
using Utility.Musics;

namespace Utility.Network.Dialog.Rating
{
    [Serializable]
    public class Rate : Packet
    {
        public string MusicRatedMID { get; set; }
        public ElementType Type { get; set; }

        public Rate(string RatedMusicMID,ElementType element)
        {
            MusicRatedMID = RatedMusicMID;
            Type = element;
        }
    }
}
