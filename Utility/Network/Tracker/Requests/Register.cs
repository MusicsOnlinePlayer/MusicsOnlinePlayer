using System;
using Utility.Network.Tracker.Identity;

namespace Utility.Network.Tracker.Requests
{
    [Serializable]
    public class Register : TrackerRequest
    {
        public Identity.Identity Identity { get; set; }
    }
    [Serializable]
    public class RegisterAck : TrackerRequest
    {
        public RegisterAck(bool isOk)
        {
            IsOk = isOk;
        }

        public bool IsOk { get; set; }
    }
}
