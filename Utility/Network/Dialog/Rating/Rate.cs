using System;

namespace Utility.Network.Dialog.Rating
{
    [Serializable]
    public class Rate
    {
        public string MusicRatedMID { get; set; }

        public Rate(string RatedMusicMID)
        {
            MusicRatedMID = RatedMusicMID;
        }
    }
}
