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
            RemoveBySocket(socket);
            Add(socket, identity);
        }

        public Identity GetIdBySocket(Socket socket)
        {
            TryGetValue(socket, out Identity identity);
            return identity;
        }

        public Socket GetSocketByID(Identity socket)
            => this.FirstOrDefault(x => x.Value == socket).Key;

        public void RemoveBySocket(Socket socket)
        {
            Remove(socket);
        }

        public ServerIdentity[] GetServerID()
        {
            return Values.Where(x => x is ServerIdentity).Select(x => (ServerIdentity)x).ToArray();
        }

        public ServerIdentity[] GetServerIDAvailable()
        {
            return Values.Where(x => x is ServerIdentity).Select(x => (ServerIdentity)x).Where(x => x.IsAvailable).ToArray();
        }

        public ClientIdentity[] GetClientIdentity()
            => Values.Where(x => x is ClientIdentity).Select(x => (ClientIdentity)x).ToArray();
    }
}
