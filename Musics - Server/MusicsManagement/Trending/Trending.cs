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
        static List<Music> GetMostLikedMusic(int length)
        {
            Dictionary<Music, int> musics = new Dictionary<Music, int>();


            foreach(var m in Indexation.GetAllMusics())
            {
                musics.Add(m, m.Rating);
            }

            musics.ToList().Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

            return (from val in musics.Take(length) select val.Key).ToList();
        }

        static List<Music> GetMostLikedMusicByGenre(string Genre, int length)
        {
            Dictionary<Music, int> musics = new Dictionary<Music, int>();


            foreach (var m in Indexation.GetAllMusics())
            {
                
                if (m.Genre.Contains(Genre))
                {
                    musics.Add(m, m.Rating);
                }              
            }

            musics.ToList().Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

            return (from val in musics.Take(length) select val.Key).ToList();
        }                   

        static List<string> GetMostPopularGenre()
        {
            var LikedMusic = GetMostLikedMusic(10);
            return (from val in LikedMusic select val.Genre).Cast<string>().ToList();

        }
    }
}
