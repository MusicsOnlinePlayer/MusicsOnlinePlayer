using System.IO;
using System.Xml;

namespace Musics___Client.AppSettings
{
    static class ApplicationSettings
    {
        public static void Setup()
        {
         
            if (!File.Exists(@"Config.xml"))
            {
                using (XmlWriter writer = XmlWriter.Create(@"Config.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Settings");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();             
                }
                XmlDocument doc = new XmlDocument();
                doc.Load(@"Config.xml");
                doc.DocumentElement.AppendChild(doc.CreateElement("HueIp"));
                doc.DocumentElement.AppendChild(doc.CreateElement("HueKey"));
                doc.DocumentElement.AppendChild(doc.CreateElement("ServerIp"));
                doc.Save(@"Config.xml");
            }
        }
        public static void Save(Settings settings)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Config.xml");
            if(settings.HueIP != null)
            {
                doc.DocumentElement["HueIp"].InnerText = settings.HueIP;
            }
            if (settings.HueKey != null)
            {
                doc.DocumentElement["HueKey"].InnerText = settings.HueKey;
            }
            if (settings.ServerIp != null)
            {
                doc.DocumentElement["ServerIp"].InnerText = settings.ServerIp;
            }
            doc.Save(@"Config.xml");
        }
        public static Settings Get()
        {
            Directory.SetCurrentDirectory(".");
            XmlDocument doc = new XmlDocument();
            doc.Load(@"./Config.xml");
            return new Settings(doc.DocumentElement["HueIp"].InnerText, doc.DocumentElement["HueKey"].InnerText, doc.DocumentElement["ServerIp"].InnerText);
        }
    }
}
