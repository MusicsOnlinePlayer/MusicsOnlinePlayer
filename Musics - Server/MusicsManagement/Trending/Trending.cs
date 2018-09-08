using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Musics___Server.MusicsManagement;
using Utility.Musics;

namespace Musics___Server.MusicsManagement.Trending
{
    public class Trending
    {
        static public IEnumerable<Music> GetMostLikedMusic(int length)
            => Indexation.GetAllMusics()
                .OrderBy(m => m.Rating)
                .Take(length);

        static public IEnumerable<Music> GetMostLikedMusicByGenre(string genre, int length)
            => Indexation.GetAllMusics()
                            .Where(m => m.Genre.Contains(genre))
                            .OrderBy(m => m.Rating)
                            .Take(length);

        static public IEnumerable<string> GetMostPopularGenre()
            => GetMostLikedMusic(10).SelectMany(x => x.Genre);
    }
}
