using Musics___Client.API.Tracker;
using System;
using Utility.Musics;
using Utility.Network.Dialog.Edits;
using Utility.Network.Tracker.Identity;

namespace Musics___Client.API
{
    public class EditMusicsServices
    {
        static private readonly Lazy<EditMusicsServices> instance = new Lazy<EditMusicsServices>(() => new EditMusicsServices());
        static public EditMusicsServices Instance { get => instance.Value; }

        private EditMusicsServices() { }

        public void SendEditMusicRequest(IElement ElementToEdit,string NewName, ServerIdentity serverIdentity)
        {
            if (ElementToEdit is Music)
                ServerManagerService.Instance.SendToServer(new EditRequest(ElementToEdit, NewName, ElementType.Music), serverIdentity);
            else
                ServerManagerService.Instance.SendToServer(new EditRequest(ElementToEdit, NewName, ElementType.Album), serverIdentity);
        }
        public void SendEditMusicRequest(IElement ElementToEdit, string NewName,string[] Genres, ServerIdentity serverIdentity)
        {
            if (ElementToEdit is Music)
                ServerManagerService.Instance.SendToServer(new EditRequest(ElementToEdit, NewName, Genres, ElementType.Music), serverIdentity);
            else
                ServerManagerService.Instance.SendToServer(new EditRequest(ElementToEdit, NewName, Genres, ElementType.Album), serverIdentity);
        }
    }
}
