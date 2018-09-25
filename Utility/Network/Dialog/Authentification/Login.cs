using System;
using Utility.Network.Users;

namespace Utility.Network.Dialog.Authentification
{
    [Serializable]
    public class Login : IPacket
    {
        public User LoginInfo { get; set; }
        public bool IsSignup { get; set; }
        public string SenderUID { get; set; }
        public bool IsFromServer { get; set; }

        public Login(User Logininfo, bool Signup)
        {
            LoginInfo = Logininfo;
            IsSignup = Signup;
        }
    }
}
