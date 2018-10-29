using Utility.Musics;

namespace Utility.Network.Dialog.Requests
{
    public class RequestSearch : Request
    {
        public RequestSearch(string name, ElementType requested)
        {
            Name = name;
            Requested = requested;
            RequestsType = RequestsTypes.Search;
        }

        public string Name { get; set; }
        public ElementType Requested { get; set; }
    }
}
