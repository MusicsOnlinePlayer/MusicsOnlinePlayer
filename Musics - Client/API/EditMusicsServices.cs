using Musics___Client.API.Tracker;
using System;
using Utility.Musics;
using Utility.Network.Dialog.Edits;

namespace Musics___Client.API
{
    public class EditMusicsServices
    {
        static private readonly Lazy<EditMusicsServices> instance = new Lazy<EditMusicsServices>(() => new EditMusicsServices());
        static public EditMusicsServices Instance { get => instance.Value; }

        private EditMusicsServices() { }

        public void SendEditMusicRequest(IElement ElementToEdit,string NewName)
        {
            if (ElementToEdit is Music)
                ServerManagerService.Instance.SendObject(new EditRequest(ElementToEdit, NewName, ElementType.Music));
            else
                ServerManagerService.Instance.SendObject(new EditRequest(ElementToEdit, NewName, ElementType.Album));
        }
        public void SendEditMusicRequest(IElement ElementToEdit, string NewName,string[] Genres)
        {
            if (ElementToEdit is Music)
                ServerManagerService.Instance.SendObject(new EditRequest(ElementToEdit, NewName, Genres, ElementType.Music));
            else
                ServerManagerService.Instance.SendObject(new EditRequest(ElementToEdit, NewName, Genres, ElementType.Album));
        }
    }
}
