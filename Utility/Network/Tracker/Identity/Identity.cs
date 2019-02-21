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
            if (obj == null) return false;
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

        public static bool operator ==(Identity id1, Identity id2)
            => id1.Equals(id2);

        public static bool operator !=(Identity id1, Identity id2)
            => !id1.Equals(id2);
    }
}
