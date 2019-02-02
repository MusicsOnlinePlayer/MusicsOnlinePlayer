using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musics___Client.API.Tracker
{
    public class ServerManagerService
    {
        static private readonly Lazy<ServerManagerService> instance = new Lazy<ServerManagerService>(() => new ServerManagerService());
        public static ServerManagerService Instance { get => instance.Value; }


    }
}
