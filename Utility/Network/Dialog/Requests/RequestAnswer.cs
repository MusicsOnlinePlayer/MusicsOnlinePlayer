using System;
using System.Collections.Generic;
using Utility.Musics;
using Utility.Network.Users;

namespace Utility.Network.Dialog
{
    [Serializable]
    public class RequestAnswer : IPacket
    {
        public string SenderUID { get; set; }
        public bool IsFromServer { get; set; }

        public RequestsTypes RequestsTypes { get; set; }

        private readonly List<IElement> answerList = new List<IElement>();
        public IReadOnlyList<IElement> AnswerList
        {
            get { return answerList; }
            set
            {
                answerList.Clear();
                answerList.AddRange(value);
            }
        }
        public ElementType Requested { get; set; }

        public Music Binaries { get; set; }

        public List<Music> Favorites = new List<Music>();

        public List<User> Users = new List<User>();

        public bool IsAccepted { get; set; }

        public object MusicByGenre { get; set; }
        public ElementType Type { get; set; }

        public RequestAnswer(List<IElement> answerlist, ElementType requested)
        {
            Requested = requested;
            AnswerList = answerlist;
            RequestsTypes = RequestsTypes.Search;
        }

        public RequestAnswer(Music requested)
        {
            Binaries = requested;
            RequestsTypes = RequestsTypes.MusicsBinaries;
        }

        public RequestAnswer(List<Music> favorites)
        {
            Favorites = favorites;
            RequestsTypes = RequestsTypes.Favorites;
        }

        public RequestAnswer(List<User> AnswerUsers, bool IsRequestAccepted)
        {
            IsAccepted = IsRequestAccepted;
            Users = AnswerUsers;
            RequestsTypes = RequestsTypes.Users;
        }

        public RequestAnswer(ElementType type, object MusicbyGenre)
        {
            MusicByGenre = MusicbyGenre;
            Type = type;
            RequestsTypes = RequestsTypes.Genres;
        }
    }
}
