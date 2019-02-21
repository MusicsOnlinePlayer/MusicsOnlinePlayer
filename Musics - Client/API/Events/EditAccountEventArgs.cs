using System;
using Utility.Network.Tracker.Identity;

namespace Musics___Client.API.Events
{
    public class EditAccountEventArgs : EventArgs
    {
        public EditAccountEventArgs(string newPassword,ServerIdentity serveridentity ,string newName = null)
        {
            NewName = newName;
            NewPassword = newPassword;
            ServerIdentity = serveridentity;
        }

        public ServerIdentity ServerIdentity { get; set; }
        public string NewName { get; set; }
        public string NewPassword { get; set; }
    }
}
