using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Net;
using Utility.Network.Tracker.Identity;

namespace Tracker.ServersXML
{
    public static class ServerXml
    {
        public const string Path = @"ServersIP.xml";

        public static void Setup()
        {
            if (!File.Exists(Path))
            {
                using (var writer = XmlWriter.Create(Path))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Servers");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }

        public static void AddServerToXml(ServerIdentity si)
        {
            if (si == null ) return;
            if (IsExisting(si)) return;
            XmlDocument doc = new XmlDocument();
            doc.Load(Path);

            XmlNode nodeServer = doc.CreateElement("Server");

            XmlNode nodeIP = doc.CreateElement("Ip");
            nodeIP.InnerText = si.IPEndPoint.Address.ToString();
            nodeServer.AppendChild(nodeIP);

            XmlNode nodePort = doc.CreateElement("Port");
            nodePort.InnerText = si.IPEndPoint.Port.ToString();
            nodeServer.AppendChild(nodePort);

            doc.DocumentElement.AppendChild(nodeServer);

            doc.Save(Path);

        }

        public static bool IsExisting(ServerIdentity identity)
        {
            foreach(var p in GetServers())
            {
                if (p.IPEndPoint.Address == identity.IPEndPoint.Address && p.IPEndPoint.Port == identity.IPEndPoint.Port)
                    return true;
            }
            return false;
        }

        public static ServerIdentity[] GetServers()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Path);
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("Server");
            return nodes.Cast<XmlNode>().Select(x => GetServer(x)).ToArray();

        }

        public static ServerIdentity GetServer(XmlNode node)
        {
            if (!IPAddress.TryParse(node["Ip"].InnerText, out IPAddress iP)) throw new Exception();
            if (!int.TryParse(node["Port"].InnerText, out int i)) throw new Exception();
            var si = new ServerIdentity()
            {
                IPEndPoint = new IPEndPoint(iP, i)
            };

            return si;
        }
    }
}
