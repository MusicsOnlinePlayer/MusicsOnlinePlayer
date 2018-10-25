using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using Musics___Server.MusicsManagement;
using Utility.Musics;
using Utility.Network.Users;

namespace Musics___Server.Usersinfos
{
    static class UsersInfos
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
                        if (GetPlaylist(nM["MID"].InnerText) == null)
                        {
                            Music tmpM = Indexation.GetMusicByID(nM["MID"].InnerText);
                            tmpM.FileBinary = null;
                            tmp.Add(tmpM);
                        }                      
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
                var name = n["Name"].InnerText;
                var UID = n["UID"].InnerText;
                var cryptedCredential = new CryptedCredentials(name, UID);
                var user = new User(cryptedCredential);
                user.Rank = GetRankOfUser(user.UID);
                UsersList.Add(user);
            }
            return UsersList;
        }

        public static User GetUser(string UID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"users.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("User");

            var node = nodes.Cast<XmlNode>().SingleOrDefault(n => n["UID"].InnerText == UID);
            User user = null;
            if (node != null)
            {
                var name = node["Name"].InnerText;
                var uid = node["UID"].InnerText;
                var cryptedCredential = new CryptedCredentials(name, UID);
                user = new User(cryptedCredential);
                user.Rank = GetRankOfUser(user.UID);
            }
            return user;
           
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
                    var name = n["Name"].InnerText;
                    var UID = n["UID"].InnerText;
                    var cryptedCredential = new CryptedCredentials(name, UID);
                    var user = new User(cryptedCredential);
                    user.Rank = GetRankOfUser(user.UID);

                    UsersList.Add(user);
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
            if (GetPlaylist(playlist.MID) != null)
                return;

            XmlDocument doc = new XmlDocument();
            doc.Load(@"users.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("User");
            XmlAttribute xmlAttributeName;
            XmlAttribute xmlAttributeProtection;
            XmlAttribute xmlAttributeRate;
            XmlAttribute xmlAttributeMID;

            foreach (XmlNode n in nodes)
            {
                if (n["UID"].InnerText == UID)
                {
                    XmlNode playlistnode = doc.CreateElement("Playlist");

                    xmlAttributeName = doc.CreateAttribute("Name");
                    xmlAttributeName.InnerText = playlist.Name;

                    xmlAttributeProtection = doc.CreateAttribute("Level");
                    xmlAttributeProtection.InnerText = playlist.Private.ToString();

                    xmlAttributeRate = doc.CreateAttribute("Rating");
                    xmlAttributeRate.InnerText = "0";

                    xmlAttributeMID = doc.CreateAttribute("MID");
                    xmlAttributeMID.InnerText = playlist.MID;

                    playlistnode.Attributes.Append(xmlAttributeProtection);
                    playlistnode.Attributes.Append(xmlAttributeName);
                    playlistnode.Attributes.Append(xmlAttributeRate);
                    playlistnode.Attributes.Append(xmlAttributeMID);

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

        public static IEnumerable<Playlist> GetPlaylists(string UID)
        {
            List<Playlist> playlists = new List<Playlist>();

            XmlDocument doc = new XmlDocument();
            doc.Load(@"users.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("User");
            foreach (XmlNode n in nodes)
            {
                XmlNodeList PlaylistNode = n.SelectNodes("UserPlaylists/Playlist");

                foreach (XmlNode p in PlaylistNode)
                {
                    Playlist playlist = new Playlist(new User(n["Name"].InnerText), p.Attributes["Name"].InnerText);
                    foreach (XmlNode m in p.SelectNodes("Music"))
                    {
                        playlist.musics.Add(Indexation.GetMusicByID(m.InnerText));
                    }
                    playlist.Rating = Convert.ToInt32(p.Attributes["Rating"].InnerText);
                    if (p.Attributes["Level"].InnerText == true.ToString())
                    {
                        if (n["UID"].InnerText == UID)
                        {
                            playlist.Private = true;
                            playlists.Add(playlist);
                        }
                    }
                    else
                    {
                        playlist.Private = false;
                        playlists.Add(playlist);
                    }
                }
            }
            return playlists;
        }
        public static void RatePlaylist(string MID, bool isPositive)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"users.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("User");
            foreach (XmlNode n in nodes)
            {
                XmlNodeList PlaylistNode = n.SelectNodes("UserPlaylists/Playlist");

                foreach (XmlNode p in PlaylistNode)
                {
                    if (p.Attributes["MID"].InnerText == MID)
                    {
                        if (isPositive)
                        {
                            p.Attributes["Rating"].InnerText = (Convert.ToInt32(p.Attributes["Rating"].InnerText) + 1).ToString();
                        }
                        else
                        {
                            p.Attributes["Rating"].InnerText = (Convert.ToInt32(p.Attributes["Rating"].InnerText) - 1).ToString();
                        }
                        doc.Save(@"users.xml");
                        return;
                    }
                }
            }
        }
        public static Playlist GetPlaylist(string MID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"users.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("User");
            foreach (XmlNode n in nodes)
            {
                XmlNodeList PlaylistNode = n.SelectNodes("UserPlaylists/Playlist");

                foreach (XmlNode p in PlaylistNode)
                {
                    if (p.Attributes["MID"].InnerText == MID)
                    {
                        Playlist playlist = new Playlist(new User(n["Name"].InnerText), p.Attributes["Name"].InnerText);
                        foreach (XmlNode m in p.SelectNodes("Music"))
                        {
                            playlist.musics.Add(Indexation.GetMusicByID(m.InnerText));
                        }
                        playlist.Rating = Convert.ToInt32(p.Attributes["Rating"].InnerText);
                        if (p.Attributes["Level"].InnerText == true.ToString())
                        {

                            playlist.Private = true;
                            return playlist;

                        }
                        else
                        {
                            playlist.Private = false;
                            return playlist;
                        }
                    }
                }
            }
            return null;
        }
    }
}