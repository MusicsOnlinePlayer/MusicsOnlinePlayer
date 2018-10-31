using System;
using Utility.Network.Users;

namespace Utility.Network.Dialog.Authentification
{
    [Serializable]
    public class AuthInfo : Packet
    {
        public bool IsAccepted { get; set; }
        public Rank RankofAuthUser { get; set; } = Rank.Viewer;
        public User User { get; } 
        public AuthInfo(bool Accepted, Rank RankOfUser,string UID)
        {
            IsAccepted = Accepted;
            RankofAuthUser = RankOfUser;
            Token = new Token(UID);
        }
        public AuthInfo(bool Accepted, Rank RankOfUser, User user)
        {
            IsAccepted = Accepted;
            RankofAuthUser = RankOfUser;
            User = user;
            if (user != null)
                Token = new Token(user.UID);
        }
    }
}
