using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Musics___Server.Commands.Exceptions;
using Musics___Server.MusicsManagement;
using Musics___Server.Usersinfos;
using Utility.Network.Users;
using System.Linq;

namespace Musics___Server.Commands
{

    public sealed class CommandLineInterpreter
    {
        private static Lazy<CommandLineInterpreter> instance = new Lazy<CommandLineInterpreter>(() => new CommandLineInterpreter(), true);

        public static CommandLineInterpreter Instance { get => instance.Value; }

        private CommandLineInterpreter() { }

        public void Start()
        {
            string commandLine = string.Empty;
            do
            {
                commandLine = Console.ReadLine();
                (var cmd, var arguments) = CommandSplitter(commandLine);
                try
                {
                    (var CommandType, var command) = CommandFactory.InstanciateCommand(cmd);
                    if (CommandType == ECommands.Quit)
                        break;
                    command.Execute(arguments);
                }
                catch (CommandException ex)
                {
                    Console.Write(ex.Message);
                }
            } while (true);

        }


        private (string command, IEnumerable<string> arguments) CommandSplitter(string command)
        {
            var splittedCommand = CompleteTrimmer(command).Split(' ').ToList();
            return (splittedCommand.First(), splittedCommand.Skip(1));
        }

        private string CompleteTrimmer(string command)
            => Regex.Replace(command, @"\s+", " ");
    }
    
    static class Commands
    {
        private static Regex CommandRegex = new Regex("");


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
                Console.WriteLine(Indexation.Do(Properties.Settings.Default.UseMultiThreading) + " Musics");
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
                foreach (var u in Program.MyServer.Clients.Values)
                {
                    Console.WriteLine(" - " + u.Name + " " + u.Userrank.ToString() + " " + u.UID);
                }
                Console.WriteLine("~ End.");
            }
            else if (entry == "-users -all" || entry == "-users -a")
            {
                Console.WriteLine("~ Getting all users");
                foreach (var u in UsersInfos.GetAllUsers())
                {
                    Console.WriteLine(" - " + u.Name + " " + u.Userrank.ToString() + " " + u.UID);
                }
                Console.WriteLine("~ End.");
            }
            else if (entry.Contains("-promote"))
            {

                string[] entryArgument = entry.Split('-');
                if (entryArgument.Length != 4)
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
                        Properties.Settings.Default.Save();
                        Console.WriteLine("~ Multithreading has been set to false");
                        break;
                    case "-set multithreading true":
                        Properties.Settings.Default.UseMultiThreading = true;
                        Properties.Settings.Default.Save();
                        Console.WriteLine("~ Multithreading has been set to true");
                        break;
                    default:
                        Console.WriteLine("~ Syntax not correct, please use -set 'property' 'value' ");
                        break;
                }
            }
            else if (entry.Contains("-get"))
            {
                switch (entry)
                {
                    case "-get multithreading":
                        Console.WriteLine("~ Multithreading is set to {0}", Properties.Settings.Default.UseMultiThreading.ToString());
                        break;
                    default:
                        Console.WriteLine("~ Syntax not correct, please use -get 'property'");
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
