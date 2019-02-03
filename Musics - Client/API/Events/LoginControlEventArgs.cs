using System;
using Utility.Network.Users;

namespace Musics___Client.API.Events
{
    public class LoginControlEventArgs : EventArgs
    {
        public LoginControlEventArgs(CryptedCredentials cryptedCredentials)
        {
            CryptedCredentials = cryptedCredentials;
        }

        public CryptedCredentials CryptedCredentials { get; set; }
    }
}
