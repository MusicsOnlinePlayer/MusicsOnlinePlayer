using System;
using Utility.Musics;

namespace Utility.Network.Dialog.Requests
{
    [Serializable]
    public class RequestGenre : Request
    {
        public RequestGenre(ElementType type, string genre)
        {
            Type = type;
            Genre = genre;
            RequestsType = RequestsTypes.Genres;
        }

        public ElementType Type { get; set; }
        public string Genre { get; set; }
    }
}
