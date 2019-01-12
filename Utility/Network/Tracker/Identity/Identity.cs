using System.Net;

namespace Utility.Network.Tracker.Identity
{
    public abstract class Identity : IIdentity
    {
        public virtual IPEndPoint IPEndPoint { get; set; }
    }
}
