using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Network.Tracker.Identity
{
    [Serializable]
    public class ServerIdentity : Identity
    {
        public bool IsAvailable { get; set; }
    }
}
