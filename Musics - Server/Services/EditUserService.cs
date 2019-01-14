using System.Net.Sockets;
using Utility.Network.Dialog.Edits;
using Utility.Network.Server;
using Utility.Network.Users;

namespace Musics___Server.Services
{
    public class EditUserService
    {
        public EditUserService()
        {
            Program.MyServer.OnPacketreceived += MyServer_OnPacketreceived;
        }

        private void MyServer_OnPacketreceived(object sender, PacketEventArgs a)
        {
            if (a.Packet is EditUser)
                TreatEditUser(sender as Socket, a.Packet as EditUser);
        }

        private static void TreatEditUser(Socket socket, EditUser editUser)
        {
            if (Program.MyServer.AuthService.EditUser(editUser.UIDOld, editUser.NewUser))
            {
                new EditUserReport(true, editUser.NewUser).Send(socket);

                Program.MyServer.Clients.Remove(socket);
                Program.MyServer.Clients.AddUser(editUser.NewUser, socket);
                Program.MyServer.Log.Warn($"User {editUser.NewUser.Name} has been edited");
            }
            else
            {
                Program.MyServer.Log.Warn($"Editing the user {editUser.NewUser.Name} failed !");
                new EditUserReport(false, editUser.NewUser).Send(socket);
            }
        }
    }
}
