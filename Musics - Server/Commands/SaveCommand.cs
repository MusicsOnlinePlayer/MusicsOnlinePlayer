using System.Collections.Generic;
using Musics___Server.MusicsManagement;

namespace Musics___Server.Commands
{
    class SaveCommand : BaseCommand
    {
        public override void Execute(IEnumerable<string> args)
            => Indexation.SaveAllInfos();
    }
}
