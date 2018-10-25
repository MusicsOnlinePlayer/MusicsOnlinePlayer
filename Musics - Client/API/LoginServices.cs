using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlLibrary.Network;
using Utility.Network.Dialog.Authentification;
using Utility.Network.Users;

namespace Musics___Client.API
{
    class LoginServices
    {

        void SendLogInCredentials(ICredentials credentials)
        {
            var user = new User(credentials);
            NetworkClient.SendObject(new Login(user, false));
        }

    }
}
