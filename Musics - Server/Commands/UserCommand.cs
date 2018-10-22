using System;
using System.Collections.Generic;
using System.Linq;
using Musics___Server.Commands.Exceptions;

namespace Musics___Server.Commands
{
    class UserCommand : EntryCommand
    {
        protected override ECommands CommandType => ECommands.Users;

        public override void Execute(IEnumerable<string> args)
        {
            switch (args.Count())
            {
                case 0:
                    new ConnectedUserCommand().Execute(args);
                    break;

                case 1:
                    Propagate(args);
                    break;

                default: throw new CommandException("Bad number of Arguments");
            }
        }

        private class ConnectedUserCommand : BaseCommand
        {
            public override void Execute(IEnumerable<string> args)
            {
                Log.Info("Getting all connected users");
                foreach (var u in Program.MyServer.Clients.Values)
                    Log.Info(" - " + u.Name + " " + u.Userrank.ToString() + " " + u.UID);
                Log.Info("End.");
            }
        }
    }

}
