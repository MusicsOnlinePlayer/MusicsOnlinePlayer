using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCraft.EnumExtension;
using Musics___Server.MusicsManagement;

namespace Musics___Server.Commands
{
    abstract class BaseCommand
    {
        public abstract void Execute(IEnumerable<string> args);
    }

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
            var command = CommandFactory.InstanciateCommand(newCommand);
            command.Execute(newArgs);
        }
    }
}
