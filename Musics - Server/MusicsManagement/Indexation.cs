using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Utility;
using Musics___Server.MusicsInformation;
using TagLib;


namespace Musics___Server.MusicsManagement
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
            return System.IO.File.ReadAllBytes(m.ServerPath);
        }

        public static Music GetMusicByID(string MID)
        {
            foreach (var p in GetAllMusics())
            {
                if (p.MID == MID)
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
                        tmp.Add(new Music(m.Title, new Author(m.Author.Name), "", m.Rating));
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

            TagLib.File file;

            foreach (var n in ArtistDirs)
            {
                Author CurrentArtist = new Author(Path.GetFileName(n),n);

                //Console.WriteLine(CurrentArtist.Name);

                string[] AlbumOfArtist = Directory.GetDirectories(n);

                int i = 0;
                foreach (var a in AlbumOfArtist)
                {
                    if (!Path.GetFileNameWithoutExtension(a).Contains("-ignore"))
                    {
                        CurrentArtist.albums.Add(new Album(CurrentArtist, Path.GetFileName(a),a));

                        //Console.WriteLine(" " + CurrentArtist.albums.Last().Name);


                        foreach (var m in Directory.GetFiles(a))
                        {

                            if (Path.GetExtension(m) == ".mp3" || Path.GetExtension(m) == ".flac")
                            {
                                file = TagLib.File.Create(m);
                                string Musicname = file.Tag.Title;
                                if (Musicname == null)
                                {
                                    try
                                    {
                                        Musicname = Path.GetFileNameWithoutExtension(m).Split('-')[1].Remove(0, 1);
                                    }
                                    catch
                                    {
                                        Musicname = Path.GetFileNameWithoutExtension(m);
                                    }
                                }

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

                }

                ServerMusics.Add(CurrentArtist);
            }

            return NumberofMusics;
        }

        public static void ModifyElement(object Origin, string NewName)
        {
            if (Origin is Music)
            {
                Music tmpOrigin = Origin as Music;
                foreach (var a in Indexation.ServerMusics)
                {
                    foreach (var al in a.albums)
                    {
                        foreach (var m in al.Musics)
                        {
                            if (tmpOrigin.MID == m.MID)
                            {
                                m.Title = NewName;
                                m.MID = Hash.SHA256Hash(m.Title + m.Author.Name);

                                TagLib.File file = TagLib.File.Create(m.ServerPath);
                                file.Tag.Title = m.Title;
                                file.Save();

                                MusicsInfo.EditMusicsInfo(tmpOrigin.MID, m);
                                return;
                            }
                        }
                    }
                }
            }
            if (Origin is Album)
            {
                Album tmpOrigin = Origin as Album;
                foreach (var a in Indexation.ServerMusics)
                {
                    foreach (var al in a.albums)
                    {
                        if (al.MID == tmpOrigin.MID)
                        {
                            al.Name = NewName;
                            al.MID = Hash.SHA256Hash(al.Name + Element.Album);

                            Directory.Move(al.ServerPath, Directory.GetParent(al.ServerPath) + "/" + al.Name);

                            foreach (var m in al.Musics)
                            {
                                m.Album = al;
                            }
                            return;
                        }
                    }
                }
            }
            if (Origin is Author)
            {
                //Author tmpOrigin = Origin as Author;
                //foreach (var a in Indexation.ServerMusics)
                //{
                //    if(tmpOrigin.MID == a.MID)
                //    {
                //        a.Name = NewName;
                //        a.MID = Hash.SHA256Hash(a.Name + Element.Author);

                //        //Directory.Move(a.ServerPath, Directory.GetParent(a.ServerPath) + "/" + a.Name);

                //        foreach (var al in a.albums)
                //        {
                //            al.Author = a;
                //            foreach(var m in al.Musics)
                //            {
                //                m.Author = a;
                //            }
                //        }

                //        return;
                //    }
                //}

            }
        }

        public static void SaveAllInfos()
        {
            MusicsInfo.SaveMusicsInfo(GetAllMusics());
        }

    }
}
