﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Network
{
    public interface IPacket
    {
        string SenderUID { get; set; }
        bool IsFromServer { get; set; }
    }
}
