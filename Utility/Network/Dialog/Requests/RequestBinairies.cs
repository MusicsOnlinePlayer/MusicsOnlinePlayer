using Utility.Musics;

namespace Utility.Network.Dialog.Requests
{
    public class RequestBinairies : Request
    {
        public RequestBinairies(Music requestedBinaries)
        {
            RequestedBinaries = requestedBinaries;
            RequestsType = RequestsTypes.MusicsBinaries;
        }

        public Music RequestedBinaries { get; set; }
        
    }
}
