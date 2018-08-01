using System;
using Utility.Network.Users;

namespace Utility.Network.Dialog.Edits
{
    [Serializable]
    public class EditUser
    {
        public string UIDOld { get; set; }
        public User NewUser { get; set; }

        public EditUser(string UserIdOld, User Newuser)
        {
            UIDOld = UserIdOld;
            NewUser = Newuser;
        }
    }
}
