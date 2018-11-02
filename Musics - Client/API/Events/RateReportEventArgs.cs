using System;

namespace Musics___Client.API.Events
{
    public class RateReportEventArgs : EventArgs
    {
        public bool ReportOk { get; set; }
        public string MID { get; set; }
        public int UpdatedRating { get; set; }

        public RateReportEventArgs(bool reportOk, string mID, int updatedRating)
        {
            ReportOk = reportOk;
            MID = mID;
            UpdatedRating = updatedRating;
        }
    }
}
