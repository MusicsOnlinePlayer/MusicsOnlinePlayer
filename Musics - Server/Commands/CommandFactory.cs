using System;
using Musics___Server.Commands.Exceptions;
using System.Linq;
using CodeCraft.EnumExtension;

namespace Musics___Server.Commands
{
    internal sealed class CommandFactory
    {
        public static (ECommands commandType, BaseCommand command) InstanciateCommand(string command)
        {
            var commandEnum = RetrieveEnumerator(command);
            return InstanciateCommand(commandEnum);
        }

        private static ECommands RetrieveEnumerator(string command)
        {
            try
            {
                return Enum<ECommands>.GetEnumAttributePairs<CommandSyntaxAttribute>()
                                .Single(p => p.Value.Command.Split('|').ToList().Contains(command))
                                .Key;
            }
            catch (InvalidOperationException ex)
            {
                throw new CommandException("Command does not exist", ex);
            }
        }

        private static (ECommands commandType, BaseCommand command) InstanciateCommand(ECommands command)
        {
            switch (command)
            {
                case ECommands.InitializeRepository: return (ECommands.InitializeRepository, new InitializeCommand());
                case ECommands.Indexation: return (ECommands.Indexation, new IndexationCommand());
                case ECommands.Save: return (ECommands.Save, new SaveCommand());
                case ECommands.Users: return (ECommands.Users, new UserCommand());
                case ECommands.AllUsers: return (ECommands.AllUsers, new AllUsersCommand());
                case ECommands.Set: return (ECommands.Set, new SetCommand());
                case ECommands.SetMultithreading: return (ECommands.SetMultithreading, new SetMultithreadingCommand());
                case ECommands.Get: return (ECommands.Get, new GetCommand());
                case ECommands.GetMultithreading: return (ECommands.GetMultithreading, new GetMultithreadingCommand());
                case ECommands.Promote: return (ECommands.Promote, new PromoteCommand());
                case ECommands.Quit: return (ECommands.Quit, new QuitCommand());
                default: throw new NotImplementedException();

            }
            throw new NotImplementedException();
        }
    }
}
