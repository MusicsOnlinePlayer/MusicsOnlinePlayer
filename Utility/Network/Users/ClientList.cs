using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Utility.Network.Users
{
    public class ClientList
    {
        public Dictionary<Socket, User> List = new Dictionary<Socket, User>();

        public bool Contains(string UID)
        {
            foreach (var p in List)
            {
                if (p.Value.UID == UID)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetIndex(string UID)
        {
            int a = 0;
            foreach (var p in List)
            {
                if (p.Value.UID == UID)
                {
                    return a;
                }
                a++;
            }
            return -1;
        }

        public Socket GetSocket(string UID)
        {
            foreach (var p in List)
            {
                if (p.Value.UID == UID)
                {
                    return p.Key;
                }
            }
            return null;
        }

        public User GetUser(string UID)
        {
            foreach (var p in List.Values)
            {
                if (p.UID == UID)
                {
                    return p;
                }
            }
            return null;
        }
        public User GetUser(Socket socket)
        {
            foreach (var p in List)
            {
                if (p.Key == socket)
                {
                    return p.Value;
                }
            }
            return null;
        }

        public List<User> GetPeople(string Name)
        {
            List<User> a = new List<User>();
            foreach (var p in List.Values)
            {
                try
                {
                    if (p.Name.Contains(Name))
                    {
                        a.Add(p);
                    }
                }
                catch
                {
                    Console.WriteLine("No client Error");
                }
            }
            return a;
        }

        public int Count()
        {
            return List.Count;
        }

        private bool Contains(User User)
        {
            foreach (var p in List)
            {
                if (User.UID == p.Value.UID)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddUser(User User, Socket socket)
        {
            if (Contains(User))
                return;
            List.Add(socket, User);
        }
    }
}
