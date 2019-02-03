using System;
using Utility.Musics;
using Utility.Network.Dialog;
using Musics___Client.API.Events;
using System.Collections.Generic;
using Utility.Network.Dialog.Requests;
using Utility.Network.Tracker.Identity;
using Utility.Network.Server;
using Musics___Client.API.Tracker;

namespace Musics___Client.API
{
    public class SearchServices
    {
        static private readonly Lazy<SearchServices> instance = new Lazy<SearchServices>(() => new SearchServices());
        static public SearchServices Instance { get => instance.Value; }

        private SearchServices()
        {
            ServerManagerService.Instance.PacketReceived += Instance_Packetreceived;
        }

        private void Instance_Packetreceived(object sender, PacketEventArgs a)
        {
            if (a.Packet is RequestAnswer)
            {
                var requestAnswer = a.Packet as RequestAnswer;
                if (requestAnswer.RequestsTypes == RequestsTypes.Search)
                {
                    OnSearchResultEvent(new SearchResultEventArgs(requestAnswer.AnswerList));
                }
            }
        }

        public void SearchElement(string Search, ElementType elementType) 
            => ServerManagerService.Instance.SendObject(new RequestSearch(Search, elementType));

        public event EventHandler<SearchResultEventArgs> SearchResultEvent;

        protected virtual void OnSearchResultEvent(SearchResultEventArgs e)
            => SearchResultEvent?.Invoke(this, e);


    }
}
