using System;
using Utility.Network.Tracker.Identity;

namespace Utility.Network.Tracker.Requests
{
    public class Register : TrackerRequest
    {
        public Register(Identity.Identity identity)
        {
            Identity = identity;
        }

        public Identity.Identity Identity { get; set; }
    }

    public class RegisterAck : TrackerRequest
    {
        public RegisterAck(bool isOk)
        {
            IsOk = isOk;
        }

        public bool IsOk { get; set; }
    }
}
