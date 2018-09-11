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
                Console.WriteLine("~ Removing all musics.... ");
                Indexation.ServerMusics.Clear();
                Console.WriteLine("~ Done.");
                Console.Write("~ Indexation of all musics....  ");
                Console.WriteLine(Indexation.DoIndexation(Properties.Settings.Default.UseMultiThreading) + "Musics");
                Console.WriteLine("~ Indexation done.");
            }
            else if (entry == "-save")
            {
                Console.Write("~ Saving music info ... ");
                Indexation.SaveAllInfos();
                Console.WriteLine("~ Done.");
            }
            else if (entry == "-users")
            {
                Console.WriteLine("~ Getting all connected users");
                foreach (User u in Program.MyServer.Clients.List.Values)
                {
                    Console.WriteLine(" - " + u.Name + " " + u.Userrank.ToString() + " " + u.UID);
                }
                Console.WriteLine("~ End.");
            }
            else if (entry == "-users -all" || entry == "-users -a")
            {
                Console.WriteLine("~ Getting all users");
                foreach (User u in UsersInfos.GetAllUsers())
                {
                    Console.WriteLine(" - " + u.Name + " " + u.Userrank.ToString() + " " + u.UID);
                }
                Console.WriteLine("~ End.");
            }
            else if (entry.Contains("-promote"))
            {

                string[] entryArgument = entry.Split('-');
                if(entryArgument.Length != 4)
                {
                    Console.WriteLine("~ Syntax not correct, please use -promote -UID -Rank");
                    return;
                }
                string UID_ = entryArgument[2].Replace(" ", "");
                if (Enum.TryParse(entry.Split('-')[3], out Rank rank))
                {
                    Console.WriteLine("~ Promote " + UID_ + " to " + rank.ToString());
                    Musics___Server.Program.PromoteUser(UID_, rank);

                    Console.WriteLine("~ Ok.");
                }
                else
                {
                    Console.WriteLine("~ Syntax not correct, please use -promote -UID -Rank");
                }
            }
            else if (entry.Contains("-set"))
            {
                switch (entry)
                {
                    case "-set multithreading false":
                        Properties.Settings.Default.UseMultiThreading = false;
                        Console.WriteLine("~ Multithreading has been set to false");
                        break;
                    case "-set multithreading true":
                        Properties.Settings.Default.UseMultiThreading = true;
                        Console.WriteLine("~ Multithreading has been set to true");
                        break;
                    default:
                        Console.WriteLine("~ Syntax not correct, please use -set 'property' 'value' ");
                        break;
                }
            }
            else
            {
                Console.WriteLine("~ Unkown Command " + entry);
            }
        }
    }
}
