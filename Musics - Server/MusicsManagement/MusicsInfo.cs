using System.Linq;
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

            if (TryFindMusic(OldMID, out XmlNode node))
            {
                node["Title"].InnerText = NewMusicInfo.Title;
                node["Author"].InnerText = NewMusicInfo.Author.Name;
                node["MID"].InnerText = NewMusicInfo.MID;
                doc.Save(@"Musics.xml");
            }
        }

        public static void SaveMusicInfo(Music music)
        {
            if (music.MID == null) return;
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Musics.xml");
            if (TryFindMusic(music.MID, out XmlNode node))
            {
                node["Rating"].InnerText = music.Rating.ToString();
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

        public static void SaveMusicsInfo(IEnumerable<Music> musics)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Musics.xml");

            foreach (var m in musics)
            {
                if (m.MID != null)
                {
                    if (TryFindMusic(m.MID, out XmlNode node))
                    {
                        node["Rating"].InnerText = m.Rating.ToString();
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

        public static bool TryFindMusic(string MID, out XmlNode node)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Musics.xml");
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("Music");

            node = nodes.Cast<XmlNode>().SingleOrDefault(n => n["MID"].InnerText == MID);
            return null != node;
        }

        public static Music GetMusicInfo(string MID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Musics.xml");
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("Music");
            var node = nodes.Cast<XmlNode>().SingleOrDefault(n => n["MID"].InnerText == MID);
            return null != node ? GetMusicInfo(node) : null;

        }

        public static Music GetMusicInfo(XmlNode node)
        {
            var music = new Music
            {
                Title = node["Title"].InnerText,
                Author = new Author(node["Author"].InnerText)
            };
            int.TryParse(node["Rating"].InnerText, out music.Rating);

            return music;
        }
    }
}
