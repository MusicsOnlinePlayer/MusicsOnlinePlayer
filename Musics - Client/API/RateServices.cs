using System;
using Utility.Musics;
using ControlLibrary.Network;
using Musics___Client.API.Events;
using System.Collections.Generic;
using Utility.Network.Dialog.Rating;

namespace Musics___Client.API
{
    public class RateServices
    {
        public RateServices()
        {
            NetworkClient.Packetreceived += NetworkClient_Packetreceived;
        }

        public event EventHandler<RateReportEventArgs> RateReportEvent;

        protected virtual void OnRateReportEvent(RateReportEventArgs e)
            => RateReportEvent?.Invoke(this, e);


        private void NetworkClient_Packetreceived(object sender, PacketEventArgs a)
        {
            if(a.Packet is RateReport)
            {
                RateReport report = a.Packet as RateReport;
                OnRateReportEvent(new RateReportEventArgs(report.ReportOk, report.MID, report.UpdatedRating));
            }
        }

        public void RateMusic(string ElementRatedMID,ElementType elementType)
            => NetworkClient.SendObject(new Rate(ElementRatedMID, elementType));

    }
}
