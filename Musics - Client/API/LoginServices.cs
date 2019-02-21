using Musics___Client.API.Tracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utility.Network.Dialog.Authentification;
using Utility.Network.Tracker.Identity;
using Utility.Network.Users;

namespace Musics___Client.API
{
    public class LoginServices
    {
        static private readonly Lazy<LoginServices> instance = new Lazy<LoginServices>(() => new LoginServices());
        static public LoginServices Instance { get => instance.Value; }

        public Dictionary<ServerIdentity,User> RegisteredUser = new Dictionary<ServerIdentity,User>();

        public void Init()
        {
            ServerManagerService.Instance.PacketReceived += Instance_PacketReceived;
        }

        private void Instance_PacketReceived(object sender, Utility.Network.Server.PacketEventArgs e)
        {
            if (e.Packet is AuthInfo authInfo)
            {
                authInfo = e.Packet as AuthInfo;
                if (ServerManagerService.Instance.TryGetServerIdentityByEndPoint((IPEndPoint)e.Sender.RemoteEndPoint, out ServerIdentity id))
                    if(!RegisteredUser.ContainsKey(id))
                        RegisteredUser.Add(id, authInfo.User);
            }
        }

        public bool TryGetLoggedUserByID(ServerIdentity serverIdentity, out User user)
        {
            try
            {
                user = RegisteredUser.Where(x => x.Key == serverIdentity).SingleOrDefault().Value;
                return true;
            }
            catch
            {
                user = null;
                return false;
            }
        }

        public bool ModifyUserOfServer(User NewUser,ServerIdentity serverIdentity)
        {
            try
            {
                RegisteredUser[serverIdentity] = NewUser;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
