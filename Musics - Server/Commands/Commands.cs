using System;
using Musics___Server.MusicsManagement;
using Musics___Server.Usersinfos;
using Utility.Network.Users;
using CodeCraft.Logger;
using static Musics___Server.Program;

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
                MyServer.Log.Info("Removing all musics.... ");
                Indexation.ServerMusics.Clear();
                MyServer.Log.Info("Done.");
                MyServer.Log.Info("Indexation of all musics....  ");
                MyServer.Log.Info(Indexation.Do(Properties.Settings.Default.UseMultiThreading) + "Musics");
                MyServer.Log.Info("Indexation done.");
            }
            else if (entry == "-save")
            {
                MyServer.Log.Info("Saving music info ... ");
                Indexation.SaveAllInfos();
                MyServer.Log.Info("Done.");
            }
            else if (entry == "-users")
            {
                MyServer.Log.Info("Getting all connected users");
                foreach (User u in Program.MyServer.Clients.List.Values)
                {
                    MyServer.Log.Info(" - " + u.Name + " " + u.Userrank.ToString() + " " + u.UID);
                }
                MyServer.Log.Info("End.");
            }
            else if (entry == "-users -all" || entry == "-users -a")
            {
                MyServer.Log.Info("Getting all users");
                foreach (User u in UsersInfos.GetAllUsers())
                {
                    MyServer.Log.Info(" - " + u.Name + " " + u.Userrank.ToString() + " " + u.UID);
                }
                MyServer.Log.Info("End.");
            }
            else if (entry.Contains("-promote"))
            {

                string[] entryArgument = entry.Split('-');
                if(entryArgument.Length != 4)
                {
                    MyServer.Log.Info("Syntax not correct, please use -promote -UID -Rank");
                    return;
                }
                string UID_ = entryArgument[2].Replace(" ", "");
                if (Enum.TryParse(entry.Split('-')[3], out Rank rank))
                {
                    MyServer.Log.Info("Promote " + UID_ + " to " + rank.ToString());
                    Musics___Server.Program.PromoteUser(UID_, rank);

                    MyServer.Log.Info("Ok.");
                }
                else
                {
                    MyServer.Log.Info("Syntax not correct, please use -promote -UID -Rank");
                }
            }
            else if (entry.Contains("-set"))
            {
                switch (entry)
                {
                    case "-set multithreading false":
                        Properties.Settings.Default.UseMultiThreading = false;
                        Properties.Settings.Default.Save();
                        MyServer.Log.Info("Multithreading has been set to false");
                        break;
                    case "-set multithreading true":
                        Properties.Settings.Default.UseMultiThreading = true;
                        Properties.Settings.Default.Save();
                        MyServer.Log.Info("Multithreading has been set to true");
                        break;
                    default:
                        MyServer.Log.Info("Syntax not correct, please use -set 'property' 'value' ");
                        break;
                }
            }
            else if (entry.Contains("-get"))
            {
                switch (entry)
                {
                    case "-get multithreading":
                        MyServer.Log.Info("Multithreading is set to " + Properties.Settings.Default.UseMultiThreading.ToString());
                        break;                  
                    default:
                        MyServer.Log.Info("Syntax not correct, please use -get 'property'");
                        break;
                }
            }
            else if (entry.Contains("-connect"))
            {
                string[] entryArgument = entry.Split(' ');
                Program.ServerCom.AddServer(entryArgument[1]);
            }
            else
            {
                MyServer.Log.Info("Unkown Command " + entry);
            }
        }
    }
}
