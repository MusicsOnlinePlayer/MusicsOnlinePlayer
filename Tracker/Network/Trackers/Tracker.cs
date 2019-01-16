using CodeCraft.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Utility.Network.Server;
using Utility.Network.Tracker.Identity;
using Utility.Network.Tracker.Requests;

namespace Tracker.Network.Trackers
{
    public class Tracker : TrackerH
    {
        public TrackerIdentity TrackerIdentity { get; private set; }

        private IDList Idlist = new IDList();

        public ConsoleLogger Logger = new ConsoleLogger();

        public Tracker(TrackerIdentity Ti)
        {
            TrackerIdentity = Ti;
        }

        public void Start()
        {
            Logger.Info("Starting the tracker...");
            try
            {
                StartTracker(TrackerIdentity);
            }
            catch(ServerSocketException ex)
            {
                if (ex.ExceptionType == ServerSocketErrors.AddressAlreadyTaken)
                {
                    TrackerIdentity.IPEndPoint.Port++;
                    Logger.Critical($"Port Already taken retring with {TrackerIdentity.IPEndPoint.Port.ToString()}");
                    Start();
                    return;
                }
                    
                Logger.Error("Socket Exception : "+ex.ExceptionType.ToString());
                return;
            }
            Logger.Info("Done.");
            Logger.Info("Event Setup...");
            EventSetup();
            Logger.Info("Done.");
        }

        private void EventSetup()
        {
            SocketConnected += Tracker_SocketConnected;
            SocketDisconnected += Tracker_SocketDisconnected;
            OnPacketreceived += Tracker_OnPacketreceived;
        }

        private void Tracker_SocketDisconnected(object sender, Utility.Network.Server.SocketConnectedEventArgs args)
        {
            Idlist.RemoveBySocket(args.SocketConnected);
            Logger.Info($"Socket disconnected - {Idlist.Count} clients connected");
        }

        private void Tracker_OnPacketreceived(object sender, Utility.Network.Server.PacketEventArgs a)
        {
            Logger.Info($"Receiving data from a socket - {a.Packet.GetType()}");
            if(a.Packet is TrackerRequest)
            {
                if (a.Packet is ServerRequest)
                {
                    Logger.Info("Receiving server request from the socket");
                    new ServerRequestAnswer(Idlist.GetServerID()).Send(a.Sender);
                    Logger.Info("Done.");
                    return;
                }
            }
            Logger.Warn($"Uknown IPacket ! - {a.Packet.GetType()}");
        }

        private void Tracker_SocketConnected(object sender, Utility.Network.Server.SocketConnectedEventArgs args)
        {
            Idlist.AddSocket(args.SocketConnected);
            Logger.Info($"Socket connected - {Idlist.Count} clients connected");
        }

        public void UpdateServersAvailabilty()
        {
            foreach(var p in Idlist.GetServerID())
            {
                var pc = p;
                pc.IsAvailable = CheckServer(pc.IPEndPoint);
            }    
        }

        public bool CheckServer(IPEndPoint ip)
        {
            try
            {
                TcpListener tcpListener = new TcpListener(ip);
                tcpListener.Start();
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
