using CodeCraft.Logger;
using System.Collections.Generic;

namespace Musics___Server.Commands
{
    abstract class BaseCommand
    {
        protected ILogger Log { get; } = new ConsoleLogger();
        public abstract void Execute(IEnumerable<string> args);
    }
}
