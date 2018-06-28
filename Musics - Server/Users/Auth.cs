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

        XmlDocument doc = new XmlDocument();

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

                XmlNode nodeRatedMusics = doc.CreateElement("RatedMusics");
                nodeUser.AppendChild(nodeRatedMusics);

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

    }
}
