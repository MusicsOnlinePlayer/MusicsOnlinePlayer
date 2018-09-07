using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Utility.Musics;

namespace Musics___Server.MusicsInformation
{
    static class MusicsInfo
    {
        public static void SetupMusics()
        {
            if (!File.Exists(@"Musics.xml"))
            {
                using (XmlWriter writer = XmlWriter.Create(@"Musics.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Musics");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }

        public static void EditMusicsInfo(string OldMID, Music NewMusicInfo)
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(@"Musics.xml");

            if (MusicsExisting(OldMID))
            {
                XmlNodeList nodes = doc.DocumentElement.SelectNodes("Music");

                foreach (XmlNode n in nodes)
                {
                    if (n["MID"].InnerText == OldMID)
                    {
                        n["Title"].InnerText = NewMusicInfo.Title;
                        n["Author"].InnerText = NewMusicInfo.Author.Name;
                        n["MID"].InnerText = NewMusicInfo.MID;
                        doc.Save(@"Musics.xml");
                        return;
                    }
                }
            }
        }

        public static void SaveMusicInfo(Music music)
        {
            XmlDocument doc = new XmlDocument();

            if (music.MID != null)
            {
                doc.Load(@"Musics.xml");

                if (MusicsExisting(music.MID))
                {
                    XmlNodeList nodes = doc.DocumentElement.SelectNodes("Music");

                    foreach (XmlNode n in nodes)
                    {
                        if (n["MID"].InnerText == music.MID)
                        {
                            n["Rating"].InnerText = music.Rating.ToString();
                        }
                    }
                }
                else
                {
                    XmlNode nodeMusic = doc.CreateElement("Music");

                    XmlNode nodeName = doc.CreateElement("Title");
                    nodeName.InnerText = music.Title;
                    nodeMusic.AppendChild(nodeName);

                    XmlNode nodeAuthor = doc.CreateElement("Author");
                    nodeAuthor.InnerText = music.Author.Name;
                    nodeMusic.AppendChild(nodeAuthor);

                    XmlNode nodeRating = doc.CreateElement("Rating");
                    nodeRating.InnerText = music.Rating.ToString();
                    nodeMusic.AppendChild(nodeRating);

                    XmlNode nodeMID = doc.CreateElement("MID");
                    nodeMID.InnerText = music.MID;
                    nodeMusic.AppendChild(nodeMID);

                    doc.DocumentElement.AppendChild(nodeMusic);
                }

                doc.Save(@"Musics.xml");
            }
        }

        public static void SaveMusicsInfo(IEnumerable<Music> musics)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Musics.xml");

            foreach (var m in musics)
            {
                if (m.MID != null)
                {
                    if (MusicsExisting(m.MID))
                    {
                        XmlNodeList nodes = doc.DocumentElement.SelectNodes("Music");

                        foreach (XmlNode n in nodes)
                        {
                            if (n["MID"].InnerText == m.MID)
                            {
                                n["Rating"].InnerText = m.Rating.ToString();
                            }
                        }
                    }
                    else
                    {
                        XmlNode nodeMusic = doc.CreateElement("Music");

                        XmlNode nodeName = doc.CreateElement("Title");
                        nodeName.InnerText = m.Title;
                        nodeMusic.AppendChild(nodeName);

                        XmlNode nodeAuthor = doc.CreateElement("Author");
                        nodeAuthor.InnerText = m.Author.Name;
                        nodeMusic.AppendChild(nodeAuthor);

                        XmlNode nodeRating = doc.CreateElement("Rating");
                        nodeRating.InnerText = m.Rating.ToString();
                        nodeMusic.AppendChild(nodeRating);

                        XmlNode nodeMID = doc.CreateElement("MID");
                        nodeMID.InnerText = m.MID;
                        nodeMusic.AppendChild(nodeMID);

                        doc.DocumentElement.AppendChild(nodeMusic);
                    }
                }
            }
            doc.Save(@"Musics.xml");
        }

        public static bool MusicsExisting(string MID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Musics.xml");
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("Music");

            foreach (XmlNode n in nodes)
            {
                if (n["MID"].InnerText == MID)
                {
                    return true;
                }
            }
            return false;
        }

        public static Music GetMusicInfo(string MID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Musics.xml");
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("Music");

            foreach (XmlNode n in nodes)
            {
                if (n["MID"].InnerText == MID)
                {
                    Music temp = new Music(n["Title"].InnerText, new Author(n["Author"].InnerText), "");
                    try
                    {
                        temp.Rating = Convert.ToInt32(n["Rating"].InnerText);
                    }
                    catch
                    {
                    }
                    return temp;
                }
            }
            return null;
        }
    }
}
