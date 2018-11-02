using System;
using Utility.Musics;

namespace Utility.Network.Dialog.Requests
{
    [Serializable]
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
