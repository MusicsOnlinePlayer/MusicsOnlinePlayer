using System;
using System.Net;
using ControlLibrary.Network;
using Utility.Network;
using Utility.Network.Dialog.Authentification;
using Utility.Network.Users;

namespace Musics___Client.API
{
    public delegate void LoginHandler();

    class LoginServices 
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
            if (a.Packet is AuthInfo authinfo)
            {
                if (authinfo.IsAccepted)
                {
                    NetworkClient.Packetreceived -= NetworkClient_Packetreceived;
              
                    LoggedUser = authinfo.User;
                    NetworkClient.MyToken = authinfo.Token;
                    LoginSucces?.Invoke();
                }
                else
                {
                    LoginFailed?.Invoke();
                }
            }
           
        }
        public void LogIn(CryptedCredentials cryptedCredentials)
        {
       
            NetworkClient.SendObject(new Login(cryptedCredentials, false));
        }
    }
}
