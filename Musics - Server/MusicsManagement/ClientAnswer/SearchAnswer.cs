using System;
using System.Collections.Generic;
using System.Linq;
using Utility;
using Musics___Server.Usersinfos;
using System.Net.Sockets;

namespace Musics___Server.MusicsManagement.ClientSearch
{
    class SearchAnswer
    {
        public static void Do(Request requestSearch, Socket asker)
        {
            if (Musics___Server.Program.Clients.GetUser(asker).UID != null)
            {
                Console.WriteLine("Sending to the client :");

                if (requestSearch.Requested == Element.Author)
                {
                    List<Author> result = new List<Author>();

                    foreach (Author a in Indexation.ServerMusics)
                    {
                        bool Found = Search.Find(requestSearch.Name, a.Name);
                        if (Found)
                        {
                            Author author = new Author(a.Name);
                            foreach (var al in a.albums)
                            {
                                author.albums.Add(new Album(new Author(a.Name), al.Name));
                                foreach (var m in al.Musics)
                                {
                                    Music temp = new Music(m.Title, author, "")
                                    {
                                        Rating = m.Rating,
                                        Album = new Album(al.Name),
                                        Genre = m.Genre
                                    };
                                    author.albums.Last().Add(temp);
                                }
                            }
                            result.Add(author);
                            Console.WriteLine("  " + a.Name);
                        }


                    }
                    Musics___Server.Program.SendObject(new RequestAnswer(result, Element.Author), asker);

                }
                if (requestSearch.Requested == Element.Album)
                {
                    List<Album> result = new List<Album>();

                    foreach (Author a in Indexation.ServerMusics)
                    {
                        foreach (Album al in a.albums)
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
                    Musics___Server.Program.SendObject(new RequestAnswer(result, Element.Album), asker);
                }
                if (requestSearch.Requested == Element.Music)
                {
                    List<Music> result = new List<Music>();

                    foreach (Author a in Indexation.ServerMusics)
                    {
                        foreach (Album al in a.albums)
                        {
                            foreach (Music m in al.Musics)
                            {
                                bool Found = Search.Find(requestSearch.Name, m.Title);
                                if (Found)
                                {
                                    Music temp = new Music(m.Title, new Author(a.Name), "")
                                    {
                                        Rating = m.Rating,
                                        Album = new Album(al.Name),
                                        Genre = m.Genre
                                    };

                                    result.Add(temp);
                                    Console.WriteLine("  " + m.Title);
                                }
                            }

                        }
                    }

                    Musics___Server.Program.SendObject(new RequestAnswer(result, Element.Music), asker);
                }
                if (requestSearch.Requested == Element.Playlist)
                {
                    List<Playlist> tmp = new List<Playlist>();
                    foreach (Playlist p in UsersInfos.GetPlaylists(Program.Clients.GetUser(asker).UID))
                    {
                        if (Search.Find(requestSearch.Name, p.Name))
                        {
                            tmp.Add(p);
                        }
                    }
                    Musics___Server.Program.SendObject(new RequestAnswer(tmp, Element.Playlist), asker);
                }

            }
        }
    }
}
