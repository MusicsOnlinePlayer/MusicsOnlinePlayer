using System;
using Utility.Network.Users;

namespace Utility.Network.Dialog.Authentification
{
    [Serializable]
    public class Login
    {
        public User LoginInfo { get; set; }
        public bool IsSignup { get; set; }

        public Login(User Logininfo, bool Signup)
        {
            LoginInfo = Logininfo;
            IsSignup = Signup;
        }
    }
}
