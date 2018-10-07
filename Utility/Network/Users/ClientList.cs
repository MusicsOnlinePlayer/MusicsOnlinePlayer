using System.Linq;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Utility.Network.Users
{
    public class ClientList : Dictionary<Socket, User>
    {

        public bool Contains(string UID)
            => Values.Any(x => x.UID == UID);

        public Socket GetSocket(string UID)
            => this.FirstOrDefault(x => x.Value.UID == UID).Key;

        public User GetUser(string UID)
            => Values.FirstOrDefault(x => x.UID == UID);

        public User GetUser(Socket socket)
            => this[socket];


        public IEnumerable<User> GetPeople(string Name)
            => Values.Where(u => u.Name.Contains(Name));

        private bool Contains(User User)
            => Contains(User.UID);

        public void AddUser(User User, Socket socket)
        {
            if (!Contains(User))
                Add(socket, User);
        }
    }
}
