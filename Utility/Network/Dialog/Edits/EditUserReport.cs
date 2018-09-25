using System;
using Utility.Network.Users;

namespace Utility.Network.Dialog.Edits
{
    [Serializable]
    public class EditUserReport : IPacket
    {
        public bool IsApproved { get; set; }
        public User NewUser { get; set; }

        public string SenderUID { get; set; }
        public bool IsFromServer { get; set; }

        public EditUserReport(bool Approved, User Newuser)
        {
            IsApproved = Approved;
            NewUser = Newuser;
        }
    }
}
