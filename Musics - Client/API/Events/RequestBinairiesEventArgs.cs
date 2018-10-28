using Utility.Musics;

namespace Musics___Client.API.Events
{
    public class RequestBinairiesEventArgs
    {
        public RequestBinairiesEventArgs(Music requestedMusic)
        {
            RequestedMusic = requestedMusic;
        }

        public Music RequestedMusic { get; set; }
    }
}
