using System;
using System.Collections.Generic;

namespace Musics___Server.Commands
{
    class GetMultithreadingCommand : BaseCommand
    {
        public override void Execute(IEnumerable<string> args)
        {
            Console.WriteLine("~ Multithreading is set to {0}", Properties.Settings.Default.UseMultiThreading.ToString());
        }
    }

}
