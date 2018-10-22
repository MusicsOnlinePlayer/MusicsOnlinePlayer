using System.Collections.Generic;
using Musics___Server.MusicsManagement;

namespace Musics___Server.Commands
{
    class IndexationCommand : BaseCommand
    {
        public override void Execute(IEnumerable<string> args)
            => Indexation.Do();
    }
}
