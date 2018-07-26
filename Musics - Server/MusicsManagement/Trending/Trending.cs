using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Musics___Server.MusicsManagement;


namespace Musics___Server.MusicsManagement.Trending
{
    class Trending
    {
        static List<Music> GetMostLikedMusic()
        {
            Dictionary<Music, int> musics = new Dictionary<Music, int>();


            foreach(var m in Indexation.GetAllMusics())
            {
                musics.Add(m, m.Rating);
            }

            musics.ToList().Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

            return (from val in musics.Take(10) select val.Key).ToList();
        }
        static List<Music> GetMostLikedMusicByDay()
        {

        }

        static List<Music> GetMostLikedMusicByGenre(string Genre)
        {

        }
        static List<Music> GetMostLikedMusicByDayByGenre(string Genre)
        {

        }
    }
}
