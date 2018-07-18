using System;
using System.Collections.Generic;
using System.Xml;
using Utility;
using Musics___Server.MusicsManagement;
namespace Musics___Server.Usersinfos
{
    class UsersInfos
    {
        public static void AddVoteMusic(string MID, string UID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"users.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("User");

            foreach (XmlNode n in nodes)
            {
                if (n["UID"].InnerText == UID)
                {
                    if (VoteExist(MID, UID))
                    {
                        XmlNodeList nodesMusics = n.SelectNodes("RatedMusics/Music");
                        foreach (XmlNode nM in nodesMusics)
                        {
                            if (nM["MID"].InnerText == MID)
                            {
                                nM.ParentNode.RemoveChild(nM);

                            }

                        }
                        doc.Save(@"users.xml");

                    }
                    else
                    {
                        XmlNode musicNode = doc.CreateElement("Music");

                        XmlNode nodeMID = doc.CreateElement("MID");
                        nodeMID.InnerText = MID;
                        musicNode.AppendChild(nodeMID);

                        n["RatedMusics"].AppendChild(musicNode);
                        doc.Save(@"users.xml");
                    }
                }
            }

        }

        public static List<Music> GetLikedMusics(string UserID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"users.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("User");

            List<Music> tmp = new List<Music>();

            foreach (XmlNode n in nodes)
            {
                if (n["UID"].InnerText == UserID)
                {
                    XmlNodeList nodesMusics = n.SelectNodes("RatedMusics/Music");
                    foreach (XmlNode nM in nodesMusics)
                    {
                        Music tmpM = Indexation.GetMusicByID(nM["MID"].InnerText);
                        tmpM.FileBinary = null;
                        tmp.Add(tmpM);
                    }
                }
            }
            return tmp;
        }

        public static bool VoteExist(string MID, string UID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"users.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("User");

            foreach (XmlNode n in nodes)
            {
                if (n["UID"].InnerText == UID)
                {
                    XmlNodeList nodesMusics = n.SelectNodes("RatedMusics/Music");
                    foreach (XmlNode nM in nodesMusics)
                    {
                        if (nM["MID"].InnerText == MID)
                        {
                            return true;
                        }

                    }
                }
            }
            return false;
        }

        public static List<User> GetAllUsers()
        {
            List<User> UsersList = new List<User>();
            XmlDocument doc = new XmlDocument();
            doc.Load(@"users.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("User");

            foreach (XmlNode n in nodes)
            {
                User tmp = new User
                {
                    Name = n["Name"].InnerText,
                    UID = n["UID"].InnerText
                };
                tmp.rank = GetRankOfUser(tmp.UID);

                UsersList.Add(tmp);
            }
            return UsersList;
        }

        public static User GetUser(string UID)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(@"users.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("User");

            foreach (XmlNode n in nodes)
            {
                if (UID == n["UID"].InnerText)
                {
                    User tmp = new User
                    {
                        Name = n["Name"].InnerText,
                        UID = n["UID"].InnerText
                    };
                    tmp.rank = GetRankOfUser(tmp.UID);

                    return tmp;
                }

            }
            return null;
        }

        public static List<User> SearchUser(string Username)
        {
            List<User> UsersList = new List<User>();
            XmlDocument doc = new XmlDocument();
            doc.Load(@"users.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("User");

            foreach (XmlNode n in nodes)
            {
                if (Search.Find(Username, n["Name"].InnerText))
                {
                    User tmp = new User
                    {
                        Name = n["Name"].InnerText,
                        UID = n["UID"].InnerText
                    };
                    tmp.rank = GetRankOfUser(tmp.UID);

                    UsersList.Add(tmp);
                }
            }
            return UsersList;
        }


        public static Rank GetRankOfUser(string UID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"users.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("User");
            foreach (XmlNode n in nodes)
            {
                if (n["UID"].InnerText == UID)
                {
                    return (Rank)Enum.Parse(typeof(Rank), n["Rank"].InnerText);
                }
            }
            return Rank.Viewer;
        }
        public static void SetRankOfUser(string UID, Rank rank)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"users.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("User");
            foreach (XmlNode n in nodes)
            {
                if (n["UID"].InnerText == UID)
                {
                    n["Rank"].InnerText = rank.ToString();
                }
            }
            doc.Save(@"users.xml");
        }

        public static void SaveUserPlaylist(string UID, Playlist playlist)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"users.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("User");
            XmlAttribute xmlAttribute;

            foreach (XmlNode n in nodes)
            {
                if (n["UID"].InnerText == UID)
                {
                    XmlNode playlistnode = doc.CreateElement("Playlist");
                    //playlistnode.InnerText = playlist.Name;

                    xmlAttribute = doc.CreateAttribute("Name");
                    xmlAttribute.InnerText = playlist.Name;

                    playlistnode.Attributes.Append(xmlAttribute);

                    foreach (var m in playlist.musics)
                    {
                        XmlNode nodeMusic = doc.CreateElement("Music");
                        nodeMusic.InnerText = m.MID;
                        playlistnode.AppendChild(nodeMusic);
                    }


                    n["UserPlaylists"].AppendChild(playlistnode);
                }
            }
            doc.Save(@"users.xml");
        }

        public static List<Playlist> GetPlaylists()
        {
            List<Playlist> playlists = new List<Playlist>();

            XmlDocument doc = new XmlDocument();
            doc.Load(@"users.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("User");
            foreach (XmlNode n in nodes)
            {
                XmlNodeList PlaylistNode = n.SelectNodes("UserPlaylists/Playlist");

                foreach(XmlNode p in PlaylistNode)
                {
                    Playlist playlist = new Playlist(new User(n["Name"].InnerText), p.Attributes["Name"].InnerText);
                    foreach(XmlNode m in p.SelectNodes("Music"))
                    {
                        playlist.musics.Add(Indexation.GetMusicByID(m.InnerText));
                    }
                    playlists.Add(playlist);
                }
                
            }
            return playlists;
        }
    }
}
