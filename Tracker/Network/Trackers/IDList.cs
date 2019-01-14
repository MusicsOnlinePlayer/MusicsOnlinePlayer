using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Sockets;
using Utility.Network.Tracker.Identity;

namespace Tracker.Network.Trackers
{
    public class IDList : Dictionary<Socket,Identity>
    {
        public void AddSocket(Socket socket)
        {
            Add(socket, null);
        }
        public void AddIdentity(Socket socket, Identity identity)
        {
            Add(socket, identity);
        }

        public Identity GetIdBySocket(Socket socket)
        {
            TryGetValue(socket, out Identity identity);
            return identity;
        }

        public void RemoveBySocket(Socket socket)
        {
            Remove(socket);
        }

        public ServerIdentity[] GetServerID()
        {
            return Values.Where(x => x is ServerIdentity).Select(x => (ServerIdentity)x).ToArray();
        }
    }
}
