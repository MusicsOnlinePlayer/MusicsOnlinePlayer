using System;
using Utility.Musics;

namespace Musics___Client.API.Events
{
    public class EditMusicEventArgs : EventArgs
    {
        public IElement ElementToEdit { get; set; }
        public string NewName { get; set; }
        public string[] Genre;

        public EditMusicEventArgs(IElement elementToEdit, string newName, string[] genre)
        {
            ElementToEdit = elementToEdit;
            NewName = newName;
            Genre = genre;
        }

        public EditMusicEventArgs(IElement elementToEdit, string newName)
        {
            ElementToEdit = elementToEdit;
            NewName = newName;
        }
    }
}
