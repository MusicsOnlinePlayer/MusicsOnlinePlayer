using System;
using Utility.Musics;

namespace Utility.Network.Dialog.Uploads
{
    [Serializable]
    public class UploadMusic : IPacket
    {
        public string SenderUID { get; set; }
        public bool IsFromServer { get; set; }

        public Album MusicPart { get; set; }

        public UploadMusic(Album Part)
        {
            MusicPart = Part;
        }
    }
}
