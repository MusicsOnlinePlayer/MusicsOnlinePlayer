using System;
using Utility.Network.Tracker.Identity;
using Utility.Network.Users;

namespace Musics___Client.API.Events
{
    public class LoginEventArgs : EventArgs
    {
        public LoginEventArgs(User loggedUser, ServerIdentity loggedserveridentity)
        {
            LoggedUser = loggedUser;
            Loggedserveridentity = loggedserveridentity;
        }

        public User LoggedUser { get; set; }
        public ServerIdentity Loggedserveridentity { get; set; }
    }
}
