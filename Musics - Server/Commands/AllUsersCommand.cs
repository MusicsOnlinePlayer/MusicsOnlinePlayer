using System;
using System.Collections.Generic;
using Musics___Server.Usersinfos;

namespace Musics___Server.Commands
{
    class AllUsersCommand : BaseCommand
    {
        public override void Execute(IEnumerable<string> args)
        {
        
            Console.WriteLine("~ Getting all users");
            foreach (var u in UsersInfos.GetAllUsers())
                Console.WriteLine($" - {u.Name} {u.Userrank.ToString()} {u.UID}");
            Console.WriteLine("~ End.");
        }
    }
}
