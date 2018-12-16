﻿using System.Net.Sockets;
using Utility.Network.Dialog.Edits;

namespace Musics___Server.Services
{
    public class EditUserService
    {
        public EditUserService()
        {
            Program.MyServer.OnPacketreceived += MyServer_OnPacketreceived;
        }

        private void MyServer_OnPacketreceived(object sender, EventsArgs.PacketEventArgs a)
        {
            if (a.Packet is EditUser)
                TreatEditUser(sender as Socket, a.Packet as EditUser);
        }

        private static void TreatEditUser(Socket socket, EditUser editUser)
        {
            if (Program.MyServer.AuthService.EditUser(editUser.UIDOld, editUser.NewUser))
            {
                Program.MyServer.SendObject(new EditUserReport(true, editUser.NewUser), socket);

                Program.MyServer.Clients.Remove(socket);
                Program.MyServer.Clients.AddUser(editUser.NewUser, socket);
                Program.MyServer.Log.Warn($"User {editUser.NewUser.Name} has been edited");
            }
            else
            {
                Program.MyServer.Log.Warn($"Editing the user {editUser.NewUser.Name} failed !");
                Program.MyServer.SendObject(new EditUserReport(false, editUser.NewUser), socket);
            }
        }
    }
}