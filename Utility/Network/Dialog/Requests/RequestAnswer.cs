using System;
using System.Collections.Generic;
using Utility.Musics;
using Utility.Network.Users;

namespace Utility.Network.Dialog
{
    [Serializable]
    public class RequestAnswer
    {
        public RequestsTypes RequestsTypes { get; set; }

        public object AnswerList { get; set; }
        public ElementType Requested { get; set; }

        public Music Binaries { get; set; }

        public List<Music> Favorites = new List<Music>();

        public List<User> Users = new List<User>();

        public bool IsAccepted { get; set; }

        public object MusicByGenre { get; set; }
        public ElementType Type { get; set; }

        public RequestAnswer(object answerlist, ElementType requested)
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

        public RequestAnswer(ElementType type,object MusicbyGenre)
        {
            MusicByGenre = MusicbyGenre;
            Type = type;
            RequestsTypes = RequestsTypes.Genres;
        }
    }
}
