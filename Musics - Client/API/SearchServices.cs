using System;
using System.Linq;
using Utility.Musics;
using Utility.Network.Dialog;
using Musics___Client.API.Events;
using System.Collections.Generic;
using Utility.Network.Dialog.Requests;
using Utility.Network.Tracker.Identity;
using Utility.Network.Server;
using Musics___Client.API.Tracker;
using System.Net;
using System.Collections.ObjectModel;

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
                    if (ServerManagerService.Instance.TryGetServerIdentityByEndPoint((IPEndPoint)a.Sender.RemoteEndPoint, out ServerIdentity si))
                    {
                        if (requestAnswer.AnswerList == null || requestAnswer.AnswerList.Count == 0) return;
                        var j = PopulateOfProvider(requestAnswer.AnswerList.ToList(), si);
                        OnSearchResultEvent(new SearchResultEventArgs(new ReadOnlyCollection<IElement>(j.ToList()), requestAnswer.InitialSearch));
                    }
                }
            }
        }

        public List<IElement> PopulateOfProvider(List<IElement> elements, ServerIdentity serverIdentity)
        {
            var c = elements.First().GetType();
            if (c == typeof(Music))
                return elements.Select(x => { x.Provider = serverIdentity; return x; }).ToList();

            if (c == typeof(Album))
            {
                List<Album> l = elements.Cast<Album>().ToList();
                return l.Select(x => { x.Provider = serverIdentity; x.musics = x.Musics.Select(y => { y.Provider = serverIdentity; return y; }).ToList(); return x; }).Cast<IElement>().ToList();
            }
            if (c == typeof(Author))
            {
                List<Author> l = elements.Cast<Author>().ToList();
                return l.Select(x => { x.Provider = serverIdentity; x.Albums = x.Albums.Select(z => { z.Provider = serverIdentity; z.musics = z.musics.Select(y => { y.Provider = serverIdentity; return y; }).ToList(); return z; }).ToList(); return x; }).Cast<IElement>().ToList();
            }

            if (c == typeof(Playlist))
                return elements;
                
            return null;
        }

        public void SearchElement(string Search, ElementType elementType) 
            => ServerManagerService.Instance.SendObject(new RequestSearch(Search, elementType));

        public event EventHandler<SearchResultEventArgs> SearchResultEvent;

        protected virtual void OnSearchResultEvent(SearchResultEventArgs e)
            => SearchResultEvent?.Invoke(this, e);


    }
}
