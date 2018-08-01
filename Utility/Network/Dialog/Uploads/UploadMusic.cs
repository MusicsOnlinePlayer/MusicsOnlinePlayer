using System;
using Utility.Musics;

namespace Utility.Network.Dialog.Uploads
{
    [Serializable]
    public class UploadMusic
    {
        public Album MusicPart { get; set; }

        public UploadMusic(Album Part)
        {
            MusicPart = Part;
        }
    }
}
