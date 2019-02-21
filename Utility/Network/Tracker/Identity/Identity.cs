using System;
using System.Net;

namespace Utility.Network.Tracker.Identity
{
    [Serializable]
    public abstract class Identity : IIdentity
    {
        public virtual IPEndPoint IPEndPoint { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Identity)) return false;

            var item = obj as Identity;

            return item.IPEndPoint.ToString() == this.IPEndPoint.ToString();
        }

        public override int GetHashCode()
        {
            return IPEndPoint.GetHashCode();
        }
        public override string ToString()
        {
            return IPEndPoint.ToString();
        }
    }
}
