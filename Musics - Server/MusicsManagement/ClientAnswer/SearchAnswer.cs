using System;
using System.Collections.Generic;
using System.Linq;
using Musics___Server.Usersinfos;
using System.Net.Sockets;
using Utility.Network.Dialog;
using Utility.Musics;

namespace Musics___Server.MusicsManagement.ClientSearch
{
    static class SearchAnswer
    {
        public static void Do(Request requestSearch, Socket asker)
        {
            if (Musics___Server.Program.MyServer.Clients.GetUser(asker).UID != null)
            {
                Console.WriteLine("Sending to the client :");

                if (requestSearch.Requested == Element.Author)
                {
                    List<Author> result = new List<Author>();

                    foreach (Author a in Indexation.ServerMusics.Where(x => Search.Find(requestSearch.Name, x.Name)))
                    {
                        Author author = new Author(a.Name);
                        foreach (var al in a.Albums)
                        {
                            author.Albums.Add(new Album(new Author(a.Name), al.Name));
                            foreach (var m in al.Musics)
                            {
                                Music temp = new Music(m.Title, author, "")
                                {
                                    Rating = m.Rating,
                                    Album = new Album(al.Name),
                                    Genre = m.Genre
                                };
                                author.Albums.Last().Add(temp);
                            }
                        }
                        result.Add(author);
                        Console.WriteLine("  " + a.Name);
                    }
                    Musics___Server.Program.MyServer.SendObject(new RequestAnswer(result, Element.Author), asker);
                }
                if (requestSearch.Requested == Element.Album)
                {
                    List<Album> result = new List<Album>();
                    foreach (Author a in Indexation.ServerMusics)
                    {
                        foreach (Album al in a.Albums)
                        {
                            bool Found = Search.Find(requestSearch.Name, al.Name);
                            if (Found)
                            {
                                Album tmp = new Album(new Author(al.Author.Name), al.Name);
                                foreach (var z in al.Musics)
                                {
                                    Music temp = new Music(z.Title, new Author(z.Author.Name), "")
                                    {
                                        Rating = z.Rating,
                                        Album = new Album(al.Name),
                                        Genre = z.Genre
                                    };
                                    tmp.Add(temp);
                                }
                                result.Add(tmp);
                                Console.WriteLine("  " + al.Name);
                            }
                        }
                    }
                    Musics___Server.Program.MyServer.SendObject(new RequestAnswer(result, Element.Album), asker);
                }
                if (requestSearch.Requested == Element.Music)
                {
                    var result = Indexation.GetAllMusics()
                         .Where(m => Search.Find(requestSearch.Name, m.Title))
                         .Select(m =>
                             
                         new Music()
                             {
                                 Title = m.Title,
                                 Author = new Author(m.Author.Name),
                                 Rating = m.Rating,
                                 Album = new Album(m.Album.Name),
                                 Genre = m.Genre
                             }
                         );
                    foreach (var m in result)
                        Console.WriteLine("  " + m.Title);


                    Musics___Server.Program.MyServer.SendObject(new RequestAnswer(result.ToList(), Element.Music), asker);
                }
                if (requestSearch.Requested == Element.Playlist)
                {
                    string userUID = Program.MyServer.Clients.GetUser(asker).UID;
                    var playlists = UsersInfos.GetPlaylists(userUID).Where(p => Search.Find(requestSearch.Name, p.Name));
                    Musics___Server.Program.MyServer.SendObject(new RequestAnswer(playlists, Element.Playlist), asker);
                }
            }
        }
    }
}
