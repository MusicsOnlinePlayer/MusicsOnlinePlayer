using System;
using Utility.Network.Users;

namespace Utility.Network.Dialog.Edits
{
    [Serializable]
    public class EditUserReport
    {
        public bool IsApproved { get; set; }
        public User NewUser { get; set; }

        public EditUserReport(bool Approved, User Newuser)
        {
            IsApproved = Approved;
            NewUser = Newuser;
        }
    }
}
