using System;
using Utility.Network.Users;
using Utility.Musics;

namespace Utility.Network.Dialog.Edits
{
    [Serializable]
    public class EditRequest : IPacket
    {
        public TypesEdit TypeOfEdit { get; set; }

        public string UserToEdit { get; set; }
        public Rank NewRankOfUser { get; set; }

        public object ObjectToEdit { get; set; }
        public string NewName { get; set; }
        public string[] NewGenres { get; set; }
        public ElementType TypeOfObject { get; set; }

        public string SenderUID { get; set; }
        public bool IsFromServer { get; set; }

        public EditRequest(string UIDToEdit, Rank NewRank)
        {
            UserToEdit = UIDToEdit;
            NewRankOfUser = NewRank;
            TypeOfEdit = TypesEdit.Users;
        }

        public EditRequest(object ToEdit, string NewTitle, ElementType TypeOf)
        {
            ObjectToEdit = ToEdit;
            NewName = NewTitle;
            TypeOfObject = TypeOf;
            TypeOfEdit = TypesEdit.Musics;
        }
        public EditRequest(object ToEdit, string NewTitle,string[] Genres, ElementType TypeOf)
        {
            ObjectToEdit = ToEdit;
            NewName = NewTitle;
            TypeOfObject = TypeOf;
            TypeOfEdit = TypesEdit.Musics;
            NewGenres = Genres;
        }
    }
    public enum TypesEdit
    {
        Users,
        Musics
    }
}
