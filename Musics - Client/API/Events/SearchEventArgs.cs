using System;
using Utility.Musics;

namespace Musics___Client.API.Events
{
    public class SearchEventArgs : EventArgs
    {
        public string SearchField { get; set; }
        public ElementType ElementType { get; set; }

        public SearchEventArgs(string Searchfield,ElementType type)
        {
            SearchField = Searchfield;
            ElementType = type;
        }
    }
}
