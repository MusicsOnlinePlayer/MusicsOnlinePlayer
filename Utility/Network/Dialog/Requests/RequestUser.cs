using Utility.Network.Users;

namespace Utility.Network.Dialog.Requests
{
    public class RequestUser : Request
    {
        public RequestUser(User username)
        {
            Username = username.Name;
            RequestsType = RequestsTypes.Users;
        }

        public string Username { get; set; }
    }
}
