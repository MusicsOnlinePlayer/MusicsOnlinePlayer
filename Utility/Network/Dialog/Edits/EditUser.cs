using System;
using Utility.Network.Users;

namespace Utility.Network.Dialog.Edits
{
    [Serializable]
    public class EditUser : IPacket
    {
        public string UIDOld { get; set; }
        public User NewUser { get; set; }

        public string SenderUID { get; set; }
        public bool IsFromServer { get; set; }

        public EditUser(string UserIdOld, User Newuser)
        {
            UIDOld = UserIdOld;
            NewUser = Newuser;
        }
    }
}
