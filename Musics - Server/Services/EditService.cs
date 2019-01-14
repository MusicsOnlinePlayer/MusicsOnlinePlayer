using Musics___Server.MusicsManagement;
using Musics___Server.Usersinfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Utility.Musics;
using Utility.Network.Dialog;
using Utility.Network.Dialog.Edits;
using Utility.Network.Server;
using Utility.Network.Users;

namespace Musics___Server.Services
{
    public class EditService
    {
        public EditService()
        {
            Program.MyServer.OnPacketreceived += MyServer_OnPacketreceived;
        }

        private void MyServer_OnPacketreceived(object sender, PacketEventArgs a)
        {
            if (a.Packet is EditRequest)
                TreatEditRequest(sender as Socket, a.Packet as EditRequest);
        }

        private void TreatEditRequest(Socket socket, EditRequest editRequest)
        {
            switch (editRequest.TypeOfEdit)
            {
                case TypesEdit.Users:
                    Edituser(socket, editRequest);
                    break;
                case TypesEdit.Musics:
                    EditMusic(socket, editRequest);
                    break;
            }
        }

        private static void Edituser(Socket socket, EditRequest editRequest)
        {
            if (UsersInfos.GetRankOfUser(Program.MyServer.Clients.GetUser(socket).UID) > editRequest.NewRankOfUser && UsersInfos.GetRankOfUser(Program.MyServer.Clients.GetUser(socket).UID) > UsersInfos.GetRankOfUser(editRequest.UserToEdit))
            {
                Program.PromoteUser(editRequest.UserToEdit, editRequest.NewRankOfUser);
                List<User> tmpU = new List<User>
                                {
                                    UsersInfos.GetUser(editRequest.UserToEdit)
                                };
                (new RequestAnswer(tmpU, true)).Send(socket);
                Program.MyServer.Log.Warn($"User promoted { editRequest.UserToEdit} to " + editRequest.NewRankOfUser.ToString());
            }
            else
            {
                Program.MyServer.Log.Warn($"Promoting the user {editRequest.UserToEdit} to {editRequest.NewRankOfUser.ToString()} failed !");
            }
        }

        private static void EditMusic(Socket socket, EditRequest editRequest)
        {
            if (Program.MyServer.Clients.GetUser(socket).Rank > Rank.User)
            {
                Indexation.ModifyElement(editRequest.ObjectToEdit as Element, editRequest.NewName, editRequest.NewGenres);
                Program.MyServer.Log.Warn($"The musics {editRequest.NewName} has been edited !");
            }
            else
            {
                Program.MyServer.Log.Warn($"The musics {editRequest.NewName } couldn't be edited");
            }
        }
    }
}
