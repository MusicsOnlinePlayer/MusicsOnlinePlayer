using Musics___Server.Usersinfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Utility.Network.Dialog.Authentification;
using Utility.Network.Users;

namespace Musics___Server.Services
{
    public class LoginService
    {
        public LoginService()
        {
            Setup();
        }

        private void Setup()
        {
            Program.MyServer.OnPacketreceived += MyServer_OnPacketreceived;
        }

        private void MyServer_OnPacketreceived(object sender, EventsArgs.PacketEventArgs a)
        {   
            if(a.Packet is Login)
            {
                ReceiveAuthInfo(a.Packet as Login,sender as Socket);
            }
        }

        void ReceiveAuthInfo(Login received,Socket socket)
        {
            if (received is Login)
            {
                Login auth = received as Login;

                Program.MyServer.Log.Warn("Client try to login");

                if (auth.IsSignup)
                {
                    AuthInfo authInfo = new AuthInfo(true, Rank.Viewer, new User(auth.LoginInfo));
                    Program.MyServer.AuthService.SignupUser(auth.LoginInfo);
                    Program.MyServer.Clients.Remove(socket);
                    Program.MyServer.Clients.AddUser(auth.LoginInfo, socket);
                    if (!Program.MyServer.Tokenlist.AddToken(socket, authInfo.Token))
                        return;
                    Program.MyServer.SendObject(authInfo, socket);
                }
                else
                {
                    var foundUser = UsersInfos.GetAllUsers().SingleOrDefault(u => u.UID == auth.LoginInfo.UID);
                    var isRegister = foundUser != null;
                    AuthInfo authInfo = new AuthInfo(true, Rank.Viewer, foundUser);
                    if (!Program.MyServer.Tokenlist.AddToken(socket, authInfo.Token))
                        return;
                    if (isRegister)
                    {
                        // MyServer.Clients.Remove(socket);
                        Program.MyServer.Clients.AddUser(auth.LoginInfo, socket);
                    }
                    Program.MyServer.SendObject(authInfo, socket);
                }
            }
        }
    }
}
