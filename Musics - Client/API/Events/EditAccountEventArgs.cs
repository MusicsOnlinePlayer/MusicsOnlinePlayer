using System;

namespace Musics___Client.API.Events
{
    public class EditAccountEventArgs : EventArgs
    {
        public EditAccountEventArgs(string newPassword, string newName = null)
        {
            NewName = newName;
            NewPassword = newPassword;
        }

        public string NewName { get; set; }
        public string NewPassword { get; set; }
    }
}
