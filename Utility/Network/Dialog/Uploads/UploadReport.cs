using System;

namespace Utility.Network.Dialog.Uploads
{
    [Serializable]
    public class UploadReport
    {
        public string RelativePath { get; set; }
        public bool UploadPartOk { get; set; }

        public UploadReport(string relativePath,bool UploadOk)
        {
            RelativePath = relativePath;
            UploadPartOk = UploadOk;
        }
    }
}
