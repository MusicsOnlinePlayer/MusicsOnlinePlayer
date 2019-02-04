using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Utility.Musics;
using Utility.Network;

namespace Musics___Server.MusicsInformation
{
    static class MusicsInfo
    {
        public static string DefaultMusicPath = @"C:\AllMusics";

        public static void SetupMusics()
        {
            if (!File.Exists(@"Musics.xml"))
            {
                using (var writer = XmlWriter.Create(@"Musics.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Musics");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
                SaveMusicPath(DefaultMusicPath);
            }
        }

        public static bool SaveMusicPath(string path)
        {
            if (!Function.CheckPathValidity(path)) return false;
            if (!Directory.Exists(path)) return false;

            XmlDocument doc = new XmlDocument();
            doc.Load(@"Musics.xml");

            if(TryFindMusicPath(out XmlNode node))
            {
                node.InnerText = path;
            }
            else
            {
                XmlNode NodePath = doc.CreateElement("Path");
                NodePath.InnerText = path;
                doc.DocumentElement.AppendChild(NodePath);
            }
            doc.Save(@"Musics.xml");
            return true;
        }

        public static string GetMusicPath()
        {
            if(TryFindMusicPath(out XmlNode node))
            {
                if (!Function.CheckPathValidity(node.InnerText)) return DefaultMusicPath;
                if (!Directory.Exists(node.InnerText)) return DefaultMusicPath;

                return node.InnerText;
            }
            return DefaultMusicPath;
        }

        public static bool TryFindMusicPath(out XmlNode node)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Musics.xml");
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("Path");

            node = nodes.Cast<XmlNode>().SingleOrDefault();
            return null != node;
        }

        public static void EditMusicsInfo(string OldMID, Music NewMusicInfo)
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(@"Musics.xml");

            if (TryFindMusic(OldMID, out XmlNode node))//TODO : Add tags edition
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

                if(music.Tags.Count != 0)
                {
                    XmlNode nodetag = doc.CreateElement("Tags");
                    nodetag.InnerText = string.Join(";", music.Tags.Select(w => w.Name));
                    nodeMusic.AppendChild(nodetag);
                }
                doc.DocumentElement.AppendChild(nodeMusic);
            }
            doc.Save(@"Musics.xml");

        }

        public static void SaveMusicsInfo(IEnumerable<Music> musics)
        {
            var doc = new XmlDocument();
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

                        if (m.Tags.Count != 0)
                        {
                            XmlNode nodetag = doc.CreateElement("Tags");
                            nodetag.InnerText = string.Join(";", m.Tags.Select(w => w.Name));
                            nodeMusic.AppendChild(nodetag);
                        }

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
            var ags = node["Tags"]?.InnerText.Split(';');
            var music = new Music
            {
                Title = node["Title"].InnerText,
                Author = new Author(node["Author"].InnerText),
                Tags = node["Tags"]?.InnerText.Split(';').Select(x => new Utility.Musics.Tags.Tag(x)).ToList()
            };
            int.TryParse(node["Rating"].InnerText, out music.Rating);

            return music;
        }
    }
}
