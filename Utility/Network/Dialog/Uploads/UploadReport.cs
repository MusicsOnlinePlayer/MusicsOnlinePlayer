using System;

namespace Utility.Network.Dialog.Uploads
{
    [Serializable]
    public class UploadReport : IPacket
    {
        public string SenderUID { get; set; }
        public bool IsFromServer { get; set; }

        public string RelativePath { get; set; }
        public bool UploadPartOk { get; set; }

        public UploadReport(string relativePath,bool UploadOk)
        {
            RelativePath = relativePath;
            UploadPartOk = UploadOk;
        }
    }
}
