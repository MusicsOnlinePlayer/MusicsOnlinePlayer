using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
