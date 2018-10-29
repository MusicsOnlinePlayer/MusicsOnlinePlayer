using System;
using Utility.Musics;
using Utility.Network.Users;

namespace Utility.Network.Dialog
{
    [Serializable]
    public class Request : Packet {
        public RequestsTypes RequestsType { get; set; }
    }

    public enum RequestsTypes
    {
        Search,
        MusicsBinaries,
        Favorites,
        Users,
        Genres
    }
}
