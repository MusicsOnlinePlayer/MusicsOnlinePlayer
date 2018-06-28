using System;
using System.Collections.Generic;
using System.Xml;
using Utility;

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

        //public static List<Music> GetLikedMusics(string UserID)
        //{
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(@"users.xml");

        //    XmlNodeList nodes = doc.DocumentElement.SelectNodes("User");

        //    List<Music> tmp = new List<Music>();

        //    foreach (XmlNode n in nodes)
        //    {
        //        if (n["UID"].InnerText == UserID)
        //        {
        //            XmlNodeList nodesMusics = n.SelectNodes("RatedMusics/Music");
        //            foreach (XmlNode nM in nodesMusics)
        //            {
                        
        //            }
        //        }
        //    }
        //}

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
                        if(nM["MID"].InnerText == MID)
                        {
                            return true;
                        }
                        
                    }
                }  
            }
            return false;
        }
    }
}
