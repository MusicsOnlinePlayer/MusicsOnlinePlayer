using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Musics___Server.Commands.Exceptions;
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
}
