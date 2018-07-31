using System;
using System.IO;
using System.Xml;
using Utility;

namespace Musics___Server.Authentification
{
    class AuthentificationService
    {       
        public void SetupAuth()
        {
            if (!File.Exists(@"users.xml"))
            {
                using(XmlWriter writer = XmlWriter.Create(@"users.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Users");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();                
                }
            }
        }

        readonly XmlDocument doc = new XmlDocument();

        public void SignupUser(User user)
        {
            if (!SigninUser(user))
            {
                doc.Load(@"users.xml");
                XmlNode nodeUser = doc.CreateElement("User");

                XmlNode nodeName = doc.CreateElement("Name");
                nodeName.InnerText = user.Name;
                nodeUser.AppendChild(nodeName);

                XmlNode nodeUID = doc.CreateElement("UID");
                nodeUID.InnerText = user.UID;
                nodeUser.AppendChild(nodeUID);

                XmlNode nodeRank = doc.CreateElement("Rank");
                nodeRank.InnerText = user.Userrank.ToString();
                nodeUser.AppendChild(nodeRank);

                XmlNode nodeRatedMusics = doc.CreateElement("RatedMusics");
                nodeUser.AppendChild(nodeRatedMusics);

                XmlNode nodePlaylist = doc.CreateElement("UserPlaylists");
                nodeUser.AppendChild(nodePlaylist);

                doc.DocumentElement.AppendChild(nodeUser);
                doc.Save(@"users.xml");
            }
        }

        public bool SigninUser(User user)
        {
            doc.Load(@"users.xml");
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("User");

            foreach(XmlNode n in nodes)
            {
                if (n["UID"].InnerText == user.UID)
                    return true;
            }
            return false;
        }

        public bool UserIDExit(string UID)
        {
            doc.Load(@"users.xml");
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("User");

            foreach (XmlNode n in nodes)
            {
                if (n["UID"].InnerText == UID)
                    return true;
            }
            return false;
        }

        public bool EditUser(string OldUID, User NewUser)
        {
            XmlDocument docs = new XmlDocument();
            docs.Load(@"users.xml");
            XmlNodeList nodes = docs.DocumentElement.SelectNodes("User");

            foreach (XmlNode n in nodes)
            {
                if (n["UID"].InnerText == OldUID)
                {
                    if (!UserIDExit(NewUser.UID))
                    {
                        n["Name"].InnerText = NewUser.Name;
                        n["UID"].InnerText = NewUser.UID;
                        docs.Save(@"users.xml");

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }                    
            }
            return false;
        }
    }
}
