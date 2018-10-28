using System;
using System.Collections.Generic;
using Utility.Musics;

namespace Musics___Client.API.Events
{
    public class FavoriteEventArgs
    {
        public FavoriteEventArgs(List<Music> favorites)
        {
            Favorites = favorites;
        }

        public List<Music> Favorites { get; set; }
    }
}
