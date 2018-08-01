using System;
using System.Collections.Generic;
using Utility;
using Utility.Musics;

namespace Musics___Server.MusicsManagement.Trending
{
    class Manager
    {
        public static List<Music[]> GenreTrending = new List<Music[]>();
        
        static public void RefreshTrending()
        {
            GenreTrending.Clear();

            foreach(var genre in Trending.GetMostPopularGenre())
            {
                GenreTrending.Add(Trending.GetMostLikedMusicByGenre(genre, 10).ToArray());
            }
        }
        static public List<Music> GetTrendingByGenres(string Genre)
        {
            return null;
        }
    }
}
