using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using Utility;
using Musics___Server.MusicsInformation;

namespace Musics___Server.MusicManagement
{
    static class Indexation 
    {
        public static List<Author> ServerMusics = new List<Author>();

        public static void InitRepository()
        {
            Directory.CreateDirectory(@"c:\AllMusics");
            Console.WriteLine("Directory created.");
            MusicsInfo.SetupMusics();

        }

        public static byte[] GetFileBinary(Music m)
        {
            return File.ReadAllBytes(m.ServerPath);
        }

        public static Music GetMusicByID(string MID)
        {
            foreach(var p in GetAllMusics())
            {
                if(p.MID == MID)
                {
                    return p;
                }
            }
            return null;
        }

        public static List<Music> GetAllMusics()
        {
            List<Music> tmp = new List<Music>();
            foreach (var a in Indexation.ServerMusics)
            {
                foreach (var al in a.albums)
                {
                    foreach (var m in al.Musics)
                    {
                        tmp.Add(new Music(m.Title,new Author(m.Author.Name),"",m.Rating));
                    }
                }
            }
            return tmp;
        }

        public static int DoIndexation()
        {
            //Console.WriteLine("Starting Indexation");
            string[] ArtistDirs = Directory.GetDirectories(@"c:\AllMusics");

            int NumberofMusics = 0;

            foreach (var n in ArtistDirs)
            {
                Author CurrentArtist = new Author(Path.GetFileName(n));

                //Console.WriteLine(CurrentArtist.Name);

                string[] AlbumOfArtist =  Directory.GetDirectories(n);

                int i = 0;
                foreach (var a in AlbumOfArtist)
                {
                    CurrentArtist.albums.Add(new Album(CurrentArtist,Path.GetFileName(a)));

                    //Console.WriteLine(" " + CurrentArtist.albums.Last().Name);

                    
                    foreach (var m in Directory.GetFiles(a))
                    {

                        if(Path.GetExtension(m) == ".mp3" || Path.GetExtension(m) == ".flac")
                        {
                            string Musicname = Path.GetFileNameWithoutExtension(m).Split('-').Last().Remove(0, 1);
                            Music current = new Music(Musicname, CurrentArtist, m)
                            {
                                Format = Path.GetExtension(m),
                            };
                            if (MusicsInfo.MusicsExisting(current.MID))
                            {
                                current.Rating = MusicsInfo.GetMusicInfo(current.MID).Rating;
                            }

                            NumberofMusics++;

                            CurrentArtist.albums[i].Musics.Add(current);

                            //Console.WriteLine("     " + current.Title);
                        }
                        

                    }
                    i++;
                }

                ServerMusics.Add(CurrentArtist);
            }

            return NumberofMusics;
        }

        public static void SaveAllInfos()
        {
            MusicsInfo.SaveMusicsInfo(GetAllMusics());
        }

    }
}
