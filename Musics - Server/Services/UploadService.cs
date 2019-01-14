using Musics___Server.MusicsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Utility.Network.Dialog.Uploads;
using Utility.Network.Server;
using Utility.Network.Users;

namespace Musics___Server.Services
{
    public class UploadService
    {
        public UploadService()
        {
            Program.MyServer.OnPacketreceived += MyServer_OnPacketreceived;
        }

        private void MyServer_OnPacketreceived(object sender, PacketEventArgs a)
        {
            if (a.Packet is UploadMusic)
                TreatUploadMusic(sender as Socket, a.Packet as UploadMusic);
        }

        private void TreatUploadMusic(Socket socket, UploadMusic uploadMusic)
        {
            if (Indexation.AddElement(uploadMusic) && (int)Program.MyServer.Clients.GetUser(socket).Rank > 1)
            {
                new UploadReport(null, true).Send(socket);
                Program.MyServer.Log.Warn($"The music { uploadMusic.MusicPart.Name } has been upload");
            }
            else
            {
                new UploadReport(null, false).Send(socket);
                Program.MyServer.Log.Warn($"The music { uploadMusic.MusicPart.Name } has been upload");
                Program.MyServer.Log.Warn("Upload completed with success");
            }
        }
    }
}
