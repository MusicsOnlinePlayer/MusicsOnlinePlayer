using System;
using Utility.Network.Users;

namespace Utility.Network.Dialog.Authentification
{
    [Serializable]
    public class AuthInfo
    {
        public bool IsAccepted { get; set; }
        public Rank RankofAuthUser { get; set; }

        public AuthInfo(bool Accepted, Rank RankOfUser)
        {
            IsAccepted = Accepted;
            RankofAuthUser = RankOfUser;
        }
    }
}
