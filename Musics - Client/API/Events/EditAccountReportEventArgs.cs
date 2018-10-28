using Utility.Network.Users;

namespace Musics___Client.API.Events
{
    public class EditAccountReportEventArgs
    {
        public EditAccountReportEventArgs(User editedUser, bool isApproved)
        {
            EditedUser = editedUser;
            IsApproved = isApproved;
        }

        public User EditedUser { get; set; }
        public bool IsApproved { get; set; }
    }
}
