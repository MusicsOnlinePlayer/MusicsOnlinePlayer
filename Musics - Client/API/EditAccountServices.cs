using Musics___Client.API.Events;
using Musics___Client.API.Tracker;
using System;
using Utility.Network.Dialog.Edits;
using Utility.Network.Server;
using Utility.Network.Users;
using Utility.Network.Tracker.Identity;
using System.Net;

namespace Musics___Client.API
{
    public class EditAccountServices
    {
        static private readonly Lazy<EditAccountServices> instance = new Lazy<EditAccountServices>(() => new EditAccountServices());
        static public EditAccountServices Instance { get => instance.Value; }

        private EditAccountServices()
        {
            ServerManagerService.Instance.PacketReceived += Instance_Packetreceived;
        }

        public event EventHandler<EditAccountReportEventArgs> EditAccountReport;
        protected virtual void OnEditAccountReport(EditAccountReportEventArgs e) => EditAccountReport?.Invoke(this, e);

        private void Instance_Packetreceived(object sender, PacketEventArgs a)
        {
            if(a.Packet is EditUserReport)
            {
                var editUserReport = a.Packet as EditUserReport;
                if(ServerManagerService.Instance.TryGetServerIdentityByEndPoint((IPEndPoint)a.Sender.RemoteEndPoint,out ServerIdentity identity))
                    OnEditAccountReport(new EditAccountReportEventArgs(editUserReport.NewUser, editUserReport.IsApproved,identity));            
            }
        }

        public void EditUser(string NewPassword, string oldUID, string Newname = null)
            => ServerManagerService.Instance.SendObject(new EditUser(oldUID, new User(new UserCredentials(Newname, NewPassword))));
    }
}
