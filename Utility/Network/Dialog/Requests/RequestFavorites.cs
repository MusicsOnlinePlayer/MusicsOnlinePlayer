using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Network.Dialog.Requests
{
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
