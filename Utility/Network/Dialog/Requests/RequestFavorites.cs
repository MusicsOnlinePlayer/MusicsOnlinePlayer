using System;

namespace Utility.Network.Dialog.Requests
{
    [Serializable]
    public class RequestFavorites : Request
    {
        public RequestFavorites(string userID)
        {
            UserID = userID;
            RequestsType = RequestsTypes.Favorites;
        }

        public string UserID { get; set; }
    }
}
