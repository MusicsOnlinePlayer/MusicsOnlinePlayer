using System.Collections.Generic;

namespace Musics___Server.Commands
{
    internal sealed partial class CommandFactory
    {
        public class QuitCommand : BaseCommand
        {
            public override void Execute(IEnumerable<string> args) { }
        }
    }
}
