using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musics___Server.Commands
{
    static class Info
    {
        public static void Say(string message,MsgType type)
        {
            Console.WriteLine("[{0} - {1}] " + message, type.ToString().ToUpper(), DateTime.Now.ToString("HH:mm:ss"));
        }
    }

    enum MsgType
    {
        Alert,
        Important,
        Info,
        Debug
    }
}
