using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ControlLibrary.Network;
using Utility.Network.Dialog.Authentification;
using Utility.Network.Users;

namespace Musics___Client.API
{
    public delegate void LoginHandler();

    class LoginServices : IDisposable
    {
       static private readonly Lazy<LoginServices> instance = new Lazy<LoginServices>(() => new LoginServices());
       static public LoginServices Instance { get => instance.Value; }

        public User LoggedUser { get; private set; }

      
        public event LoginHandler LoginSucces;
        public event LoginHandler LoginFailed;


        private LoginServices()
        {
            NetworkClient.ip = IPAddress.Parse(AppSettings.ApplicationSettings.Get().ServerIp);
            NetworkClient.Connect();
            NetworkClient.Packetreceived += NetworkClient_Packetreceived;
        }

        private void NetworkClient_Packetreceived(object sender, PacketEventArgs a)
        {
            if (a.Packet is AuthInfo authinfo && authinfo.IsAccepted)
            {
                LoggedUser = authinfo.User;
                LoginSucces?.Invoke();
            }
            else
            {
                LoginFailed?.Invoke();
            }
        }
        public void LogIn(CryptedCredentials cryptedCredentials)
        {
            NetworkClient.SendObject(new Login(cryptedCredentials, false));
        }

        public void Dispose() => NetworkClient.CloseSocket();
    }
}
