using System.Linq;
using System.Collections.Generic;
using System.Net.Sockets;
using Utility.Network.Users;

namespace Musics___Server.Network
{
    public class ClientList :  Dictionary<Socket, string>
    {

        public bool Contains(string UID)
            => Values.Any(x =>x == UID);

        public Socket GetSocket(string UID)
            => this.FirstOrDefault(x => x.Value == UID).Key;

       /* public User GetUser(string UID)
            => Values.FirstOrDefault(x => x == UID);*/

        public User GetUser(Socket socket)
            => Usersinfos.UsersInfos.GetUser(this[socket]);

        public bool IsConnected(string UID)
            => Values.Any(x => x == UID);

        public IEnumerable<User> GetConnectedUser()
        => Values.Select(uid => Usersinfos.UsersInfos.GetUser(uid)).Where(x => x != null);
         

         
           

        private bool Contains(User User)
            => Contains(User.UID);

        public void AddUser(CryptedCredentials credential, Socket socket)
        {
            if (!Contains(credential.UID))
                this[socket] = credential.UID ;
        }
    }
}
