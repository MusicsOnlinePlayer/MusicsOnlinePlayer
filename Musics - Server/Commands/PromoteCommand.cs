using System;
using System.Collections.Generic;
using System.Linq;
using Musics___Server.Commands.Exceptions;
using Utility.Network.Users;

namespace Musics___Server.Commands
{
    class PromoteCommand : BaseCommand
    {
        public override void Execute(IEnumerable<string> args)
        {
            if (args.Count() != 2)
                throw new CommandException("Number of arguments are not correct.");

            var UID = args.First();
            var strRank = args.Last();
            if (Enum.TryParse(strRank, out Rank rank))
            {
                Log.Info($"~romote {UID} to {rank}\t");
                Program.PromoteUser(UID, rank);
                Log.Info("Ok.");
            }
        }
    }
}
