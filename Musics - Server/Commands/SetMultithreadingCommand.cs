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
                Log.Info($"Multithreading has been set to {newValue}");
            }
            else
            {
                Log.Info($"Arguments \"{ args.First()}\" cannot be parse as bool");
            }
        }
    }
}
