using System;
using Musics___Server.MusicsManagement;
using Musics___Server.Usersinfos;
using Utility.Network.Users;

namespace Musics___Server.Commands
{
    static class Commands
    {
        public static void Do(string entry)
        {
            if (entry == "-init")
            {
                Indexation.InitRepository();
            }
            else if (entry == "-index")
            {
                Console.Write("~ Indexation of all musics....  ");
                Console.WriteLine(Indexation.DoIndexation() + "Musics");
                Console.WriteLine("~ Indexation done.");
            }
            else if (entry == "-save")
            {
                Console.Write("~ Saving music info ... ");
                Indexation.SaveAllInfos();
                Console.WriteLine("Done.");
            }
            else if (entry == "-users")
            {
                Console.WriteLine("~ Getting all connected users");
                foreach (User u in Program.Clients.List.Values)
                {
                    Console.WriteLine(" - " + u.Name + " " + u.Userrank.ToString() + " " + u.UID);
                }
                Console.WriteLine("End.");
            }
            else if (entry == "-users -all" || entry == "-users -a")
            {
                Console.WriteLine("~ Getting all users");
                foreach (User u in UsersInfos.GetAllUsers())
                {
                    Console.WriteLine(" - " + u.Name + " " + u.Userrank.ToString() + " " + u.UID);
                }
                Console.WriteLine("End.");
            }
            else if (entry.Contains("-promote"))
            {
                string UID = entry.Split('-')[2].Replace(" ", "");
                if (Enum.TryParse(entry.Split('-')[3], out Rank rank))
                {
                    Console.WriteLine("~ Promote " + UID + " to " + rank.ToString());
                    Musics___Server.Program.PromoteUser(UID, rank);

                    Console.WriteLine("Ok.");
                }
                else
                {
                    Console.WriteLine("~ Syntax not correct, please use -promote -UID -Rank");
                }
            }
            else
            {
                Console.WriteLine("~ Unkown Command " + entry);
            }
        }
    }
}
