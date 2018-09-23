using System;

namespace Utility.Network.Dialog.Rating
{
    [Serializable]
    public class RateReport : IPacket
    {
        public bool ReportOk { get; set; }
        public string MID { get; set; }
        public int UpdatedRating { get; set; }

        public string SenderUID { get; set; }
        public bool IsFromServer { get; set; }

        public RateReport(bool Reportok, string MusicID, int NewRating)
        {
            ReportOk = Reportok;
            MID = MusicID;
            UpdatedRating = NewRating;
        }
    }
}
