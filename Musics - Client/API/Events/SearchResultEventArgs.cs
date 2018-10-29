using System;
using System.Collections.Generic;
using Utility.Musics;

namespace Musics___Client.API.Events
{
    public class SearchResultEventArgs : EventArgs
    {
        public IReadOnlyList<IElement> ReceivedSearchedElement { get; set; }

        public SearchResultEventArgs(IReadOnlyList<IElement> receivedSearchedElement)
        {
            ReceivedSearchedElement = receivedSearchedElement;
        }      
    }
}
