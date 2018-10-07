using System.Collections.Generic;

namespace Musics___Server.Commands
{
    abstract class BaseCommand
    {
        public abstract void Execute(IEnumerable<string> args);
    }
}
