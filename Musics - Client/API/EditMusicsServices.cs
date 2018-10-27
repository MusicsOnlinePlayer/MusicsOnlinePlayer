using ControlLibrary.Network;
using System;
using Utility.Musics;
using Utility.Network.Dialog.Edits;

namespace Musics___Client.API
{
    public class EditMusicsServices
    {
        public void SendEditMusicRequest(IElement ElementToEdit,string NewName)
        {
            if (ElementToEdit is Music)
                NetworkClient.SendObject(new EditRequest((object)ElementToEdit, NewName, ElementType.Music));
            else
                NetworkClient.SendObject(new EditRequest((object)ElementToEdit, NewName, ElementType.Album));
        }
        public void SendEditMusicRequest(IElement ElementToEdit, string NewName,string[] Genres)
        {
            if (ElementToEdit is Music)
                NetworkClient.SendObject(new EditRequest((object)ElementToEdit, NewName, Genres, ElementType.Music));
            else
                NetworkClient.SendObject(new EditRequest((object)ElementToEdit, NewName, Genres, ElementType.Album));
        }
    }
}
