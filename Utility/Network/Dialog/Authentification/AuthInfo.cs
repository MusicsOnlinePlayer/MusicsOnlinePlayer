using System;
using Utility.Network.Users;

namespace Utility.Network.Dialog.Authentification
{
    [Serializable]
    public class AuthInfo : IPacket
    {
        public bool IsAccepted { get; set; }
        public Rank RankofAuthUser { get; set; }
        public string SenderUID { get; set; }
        public bool IsFromServer { get; set; }

        public AuthInfo(bool Accepted, Rank RankOfUser)
        {
            IsAccepted = Accepted;
            RankofAuthUser = RankOfUser;
        }
    }
}
