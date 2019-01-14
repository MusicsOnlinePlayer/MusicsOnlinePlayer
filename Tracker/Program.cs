using System;
using Tracker.Network.Trackers;
using Utility.Network.Tracker.Identity;
using System.Net;

namespace Tracker
{
    class Program
    {
        static Network.Trackers.Tracker _Tracker { get; set; }

        static void Main(string[] args)
        {
            _Tracker = new Network.Trackers.Tracker(new TrackerIdentity(new IPEndPoint(IPAddress.Any, 2003)));
            _Tracker.Start();
            Console.Read();
        }
    }
}
