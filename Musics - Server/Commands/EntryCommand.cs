using System.Collections.Generic;
using System.Linq;

namespace Musics___Server.Commands
{
    abstract class EntryCommand : BaseCommand
    {
        protected abstract ECommands CommandType { get; }
        protected string Command => CommandType.SpecificAttribute<CommandSyntaxAttribute>().Command.Split('|').First();

        public override void Execute(IEnumerable<string> args)
            => Propagate(args);

        protected virtual void Propagate(IEnumerable<string> args)
        {
            var nextArg = args.First();
            var newArgs = args.Skip(1);
            var newCommand = $"{Command} {nextArg}";
            (_, var command) = CommandFactory.InstanciateCommand(newCommand);
            command.Execute(newArgs);
        }
    }
}
