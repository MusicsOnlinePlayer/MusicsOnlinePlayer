using System.Linq;
using Musics___Server.Usersinfos;
using System.Net.Sockets;
using Utility.Network.Dialog;
using Utility.Musics;
using static Musics___Server.Program;
using Utility.Network.Dialog.Requests;
using Utility.Network;

namespace Musics___Server.MusicsManagement.ClientSearch
{
    static class SearchAnswer
    {
        public static void Do(RequestSearch requestSearch, Socket asker)
        {
            if (MyServer.Clients.GetUser(asker)?.UID != null)
            {
                MyServer.Log.Info("Sending to the client :");
                switch (requestSearch.Requested)
                {
                    case ElementType.Author:
                        DoAuthor(requestSearch, asker);
                        break;
                    case ElementType.Album:
                        DoAlbum(requestSearch, asker);
                        break;
                    case ElementType.Music:
                        DoMusic(requestSearch, asker);
                        break;
                    case ElementType.Playlist:
                        DoPlaylist(requestSearch, asker);
                        break;
                }
            }
        }

        private static void DoPlaylist(RequestSearch requestSearch, Socket asker)
        {
            string userUID = MyServer.Clients.GetUser(asker).UID;
            var playlists = UsersInfos.GetPlaylists(userUID).Where(p => Search.Find(requestSearch.Name, p.Name));
            (new RequestAnswer(playlists.Cast<IElement>().ToList(), ElementType.Playlist)).Send(asker);
        }

        private static void DoMusic(RequestSearch requestSearch, Socket asker)
        {
            var result = Indexation.GetAllMusics()
                 .Where(m => Search.Find(requestSearch.Name, m.Title)).OrderBy(x => Search.FindStrength(requestSearch.Name,x.Title)).OrderByDescending(x => x.Rating);
            foreach (var m in result)
                MyServer.Log.Info("  " + m.Title);
             
            requestSearch.SenderUID = MyServer.Clients.GetUser(asker).UID;

            ServerCom.GlobalSend(requestSearch);
            (new RequestAnswer(result.Cast<IElement>().ToList(), ElementType.Music)).Send(asker);
        }

        private static void DoAlbum(RequestSearch requestSearch, Socket asker)
        {
            var result = Indexation.GetAlbums(x => Search.Find(requestSearch.Name, x.Name));
            foreach(var a in result)
                MyServer.Log.Info($"  {a.Name}");

            (new RequestAnswer(result.Cast<IElement>().ToList(), ElementType.Album)).Send(asker);
        }

        private static void DoAuthor(RequestSearch requestSearch, Socket asker)
        {
            var result = Indexation.GetAuthors(x => Search.Find(requestSearch.Name, x.Name));
            foreach (var a in result)
                MyServer.Log.Info($"  {a.Name}");
            (new RequestAnswer(result.Cast<IElement>().ToList(), ElementType.Author)).Send(asker);
        }
    }
}
