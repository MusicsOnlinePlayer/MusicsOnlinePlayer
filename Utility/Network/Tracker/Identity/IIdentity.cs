﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Network.Tracker.Identity
{
    public interface IIdentity
    {
        IPEndPoint IPEndPoint { get; set; }
    }
}
