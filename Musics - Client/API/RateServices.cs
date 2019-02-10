using System;
using Utility.Musics;
using Musics___Client.API.Events;
using Utility.Network.Dialog.Rating;
using Utility.Network.Dialog;
using Utility.Network.Server;
using Musics___Client.API.Tracker;
using Utility.Network.Dialog.Requests;

namespace Musics___Client.API
{
    public class RateServices
    {
        static private readonly Lazy<RateServices> instance = new Lazy<RateServices>(() => new RateServices());
        static public RateServices Instance { get => instance.Value; }
        private RateServices()
        {
            ServerManagerService.Instance.PacketReceived += Instance_Packetreceived;
            ServerManagerService.Instance.ServerAdded += Instance_ServerAdded;
        }

        private void Instance_ServerAdded(object sender, ServerAddedEventArgs e)
        {
            ServerManagerService.Instance.SendToServer(new RequestFavorites(ServerManagerService.Instance.Me.UID),e.ServerIdentity);
        }

        public event EventHandler<RateReportEventArgs> RateReportEvent;
        protected virtual void OnRateReportEvent(RateReportEventArgs e)
            => RateReportEvent?.Invoke(this, e);

        public event EventHandler<FavoriteEventArgs> FavoriteReceivedEvent;
        protected virtual void OnFavoriteReceivedEvent(FavoriteEventArgs e)
            => FavoriteReceivedEvent?.Invoke(this, e);

        private void Instance_Packetreceived(object sender, PacketEventArgs a)
        {
            if(a.Packet is RateReport)
            {
                var report = a.Packet as RateReport;
                OnRateReportEvent(new RateReportEventArgs(report.ReportOk, report.MID, report.UpdatedRating));
            }
            if(a.Packet is RequestAnswer)
            {
                var requestAnswer = a.Packet as RequestAnswer;
                if(requestAnswer.RequestsTypes == RequestsTypes.Favorites)
                    OnFavoriteReceivedEvent(new FavoriteEventArgs(requestAnswer.Favorites));
            }
        }

        public void RateMusic(string ElementRatedMID, ElementType elementType)
            => ServerManagerService.Instance.SendObject(new Rate(ElementRatedMID, elementType));
    }
}
