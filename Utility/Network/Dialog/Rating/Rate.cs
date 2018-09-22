using System;
using Utility.Musics;

namespace Utility.Network.Dialog.Rating
{
    [Serializable]
    public class Rate : IPacket
    {
        public string MusicRatedMID { get; set; }
        public ElementType Type { get; set; }
        public string SenderUID { get; set; }
        public bool IsFromServer { get; set; }

        public Rate(string RatedMusicMID,ElementType element)
        {
            MusicRatedMID = RatedMusicMID;
            Type = element;
        }
    }
}
