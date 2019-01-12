using System;
using Utility.Network;
using Utility.Network.Server;
using Utility.Network.Tracker.Identity;

namespace Tracker.Network.Tracker
{
    public class TrackerH : ServerComunication
    {
        public delegate void PacketReceivedEvent(object sender, PacketEventArgs a);
        public delegate void PacketReceivedHandler(object sender, PacketEventArgs a);
        public event PacketReceivedHandler OnPacketreceived;

        public void StartTracker(TrackerIdentity ti)
        {
            TryBindSocket(ti.IPEndPoint);
            TryListen();
            BeginAcceptConnection();
            DataReceived += TrackerH_DataReceived;
        }

        private void TrackerH_DataReceived(object sender, DataReceivedFromSocketArgs args)
        {
            try
            {
                OnPacketreceived(null,new PacketEventArgs((IPacket)Function.Deserialize(new MessageTCP(args.DataReceived)),args.SocketConnected));
            }
            catch
            {
                throw new InvalidObjectException();
            }
        }
    }

    public class InvalidObjectException : Exception  { }
}
