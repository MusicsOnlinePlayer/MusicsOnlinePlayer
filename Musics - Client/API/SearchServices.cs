using System;
using Utility.Musics;
using Utility.Network.Dialog;
using ControlLibrary.Network;
using Musics___Client.API.Events;
using System.Collections.Generic;

namespace Musics___Client.API
{
    public class SearchServices
    {
        public SearchServices()
        {
            NetworkClient.Packetreceived += NetworkClient_Packetreceived;
        }

        private void NetworkClient_Packetreceived(object sender, PacketEventArgs a)
        {
            if(a.Packet is RequestAnswer)
            {
                RequestAnswer requestAnswer = a.Packet as RequestAnswer;
                if(requestAnswer.RequestsTypes == RequestsTypes.Search)
                {
                    OnSearchResultEvent(new SearchResultEventArgs(requestAnswer.AnswerList));
                }
            }
        }

        public void SearchElement(string Search, ElementType elementType) 
            => NetworkClient.SendObject(new Request(Search, elementType));

        public event EventHandler<SearchResultEventArgs> SearchResultEvent;

        protected virtual void OnSearchResultEvent(SearchResultEventArgs e) 
            => SearchResultEvent?.Invoke(this, e);

        
    }
}
