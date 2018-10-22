using System;
using System.Collections.Generic;
using Musics___Server.Usersinfos;

namespace Musics___Server.Commands
{
    class AllUsersCommand : BaseCommand
    {
        public override void Execute(IEnumerable<string> args)
        {
        
            Log.Info("Getting all users");
            foreach (var u in UsersInfos.GetAllUsers())
                Log.Info($" - {u.Name} {u.Userrank.ToString()} {u.UID}");
            Log.Info("End.");
        }
    }
}
