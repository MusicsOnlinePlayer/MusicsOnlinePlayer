using Utility.Network.Users;

using Utility.Network.Tracker.Identity;

namespace Musics___Client.API.Events
{
    public class EditAccountReportEventArgs
    {
        public EditAccountReportEventArgs(User editedUser, bool isApproved, ServerIdentity serverIdentity)
        {
            EditedUser = editedUser;
            IsApproved = isApproved;
            ServerIdentity = serverIdentity;
        }

        public ServerIdentity ServerIdentity { get; set; }
        public User EditedUser { get; set; }
        public bool IsApproved { get; set; }
    }
}
