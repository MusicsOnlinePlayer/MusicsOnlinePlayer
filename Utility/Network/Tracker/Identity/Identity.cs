using System;
using System.Net;

namespace Utility.Network.Tracker.Identity
{
    [Serializable]
    public abstract class Identity : IIdentity
    {
        public virtual IPEndPoint IPEndPoint { get; set; }
    }
}
