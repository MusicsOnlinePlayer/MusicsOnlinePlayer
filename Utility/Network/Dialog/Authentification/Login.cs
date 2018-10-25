using System;
using Utility.Network.Users;

namespace Utility.Network.Dialog.Authentification
{
    [Serializable]
    public class Login : Packet
    {
        public CryptedCredentials LoginInfo { get; set; }
        public bool IsSignup { get; set; }
    
        public Login(CryptedCredentials Logininfo, bool Signup)
        {
            LoginInfo = Logininfo;
            IsSignup = Signup;
        }
    }
}
