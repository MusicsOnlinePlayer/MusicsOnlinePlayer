using System;
using Utility.Musics;

namespace Utility.Network.Dialog.Rating
{
    [Serializable]
    public class Rate
    {
        public string MusicRatedMID { get; set; }
        public Element Type { get; set; }

        public Rate(string RatedMusicMID,Element element)
        {
            MusicRatedMID = RatedMusicMID;
            Type = element;
        }
    }
}
