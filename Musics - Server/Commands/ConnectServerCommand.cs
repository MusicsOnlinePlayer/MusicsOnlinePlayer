using System.Collections.Generic;
using System.Linq;
using Musics___Server.Commands.Exceptions;

namespace Musics___Server.Commands
{
    class ConnectServerCommand : BaseCommand
    {

        public override void Execute(IEnumerable<string> args)
        {
            if (args.Count() != 1)
                throw new CommandException("Number of arguments are not correct.");
            Program.ServerCom.AddServer(args.First());
        }
    }
}
