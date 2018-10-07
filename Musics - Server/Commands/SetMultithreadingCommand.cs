using System;
using System.Collections.Generic;
using System.Linq;

namespace Musics___Server.Commands
{
    class SetMultithreadingCommand : BaseCommand
    {
        public override void Execute(IEnumerable<string> args)
        {
            if (bool.TryParse(args.First(), out bool newValue))
            {
                Properties.Settings.Default.UseMultiThreading = newValue;
                Console.WriteLine($"~ Multithreading has been set to {newValue}");
            }
            else
            {
                Console.WriteLine($"Arguments \"{ args.First()}\" cannot be parse as bool");
            }

        }
    }

}
