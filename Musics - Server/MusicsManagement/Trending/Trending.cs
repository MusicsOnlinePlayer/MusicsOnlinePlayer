using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Musics___Server.MusicsManagement;


namespace Musics___Server.MusicsManagement.Trending
{
    public class Trending
    {
        static public List<Music> GetMostLikedMusic(int length)
        {
            Dictionary<Music, int> musics = new Dictionary<Music, int>();


            foreach(var m in Indexation.GetAllMusics())
            {
                musics.Add(m, m.Rating);
            }

            musics.ToList().Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

            return (from val in musics.Take(length) select val.Key).ToList();
        }

        static public List<Music> GetMostLikedMusicByGenre(string Genre, int length)
        {
            Dictionary<Music, int> musics = new Dictionary<Music, int>();


            foreach (var m in Indexation.GetAllMusics())
            {
                
                if (m.Genre.Contains(Genre))
                {
                    musics.Add(new Music(m.Title,new Author(m.Author.Name),null,m.Rating), m.Rating);
                }              
            }

            musics.ToList().Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

            return (from val in musics.Take(length) select val.Key).ToList();
        }                   

        static public List<string> GetMostPopularGenre()
        {
            var LikedMusic = GetMostLikedMusic(10);
            return (from val in LikedMusic select val.Genre).Cast<string>().ToList();

        }
    }
}
