using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Musics___Server.MusicsInformation;
using TagLib;
using Utility.Musics;
using Utility.Network.Dialog.Uploads;

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
                foreach (var al in a.Albums)
                {
                    foreach (var m in al.Musics)
                    {
                        tmp.Add(m);
                    }
                }
            }
            return tmp;
        }

        public static bool IsElementExisting(object element, Element type)
        {
            switch (type)
            {
                case Element.Author:
                    Author tmp = element as Author;
                    foreach (var a in ServerMusics)
                    {
                        if (a.MID == tmp.MID)
                        {
                            return true;
                        }
                    }
                    break;
                case Element.Album:
                    Album Albumtmp = element as Album;
                    foreach (var a in ServerMusics)
                    {
                        foreach (var al in a.Albums)
                        {
                            if (al.MID == Albumtmp.MID)
                            {
                                return true;
                            }
                        }
                    }
                    break;
                case Element.Music:
                    if (MusicsInfo.MusicsExisting((element as Music).MID))
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }

        public static int DoIndexation()
        {
            //Console.WriteLine("Starting Indexation");
            string[] ArtistDirs = Directory.GetDirectories(@"c:\AllMusics");

            int NumberofMusics = 0;

            TagLib.File file;

            foreach (var n in ArtistDirs)
            {
                Author CurrentArtist = new Author(Path.GetFileName(n), n);

                string[] AlbumOfArtist = Directory.GetDirectories(n);

                int i = 0;
                foreach (var a in AlbumOfArtist)
                {
                    if (!Path.GetFileNameWithoutExtension(a).Contains("-ignore"))
                    {
                        CurrentArtist.Albums.Add(new Album(CurrentArtist, Path.GetFileName(a), a));

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
                                    Genre = file.Tag.Genres
                                };
                                if (current.Genre.Length == 0)
                                {
                                    current.Genre = new string[] { "Unknown" };
                                }
                                if (MusicsInfo.MusicsExisting(current.MID))
                                {
                                    current.Rating = MusicsInfo.GetMusicInfo(current.MID).Rating;
                                }

                                NumberofMusics++;

                                CurrentArtist.Albums[i].Musics.Add(current);
                            }
                        }
                        i++;
                    }
                }
                ServerMusics.Add(CurrentArtist);
            }

            return NumberofMusics;
        }

        public static void ModifyElement(object Origin, string NewName,string[] Genres)
        {
            if (Origin is Music)
            {
                Music tmpOrigin = Origin as Music;
                foreach (var a in Indexation.ServerMusics)
                {
                    foreach (var al in a.Albums)
                    {
                        foreach (var m in al.Musics)
                        {
                            if (tmpOrigin.MID == m.MID)
                            {
                                m.Title = NewName;
                                m.MID = Hash.SHA256Hash(m.Title + m.Author.Name);

                                TagLib.File file = TagLib.File.Create(m.ServerPath);
                                file.Tag.Title = m.Title;

                                if(Genres != null)
                                {
                                    m.Genre = Genres;
                                    file.Tag.Genres = Genres;
                                }

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
                    foreach (var al in a.Albums)
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

        public static bool AddElement(UploadMusic tmp)
        {
            if (!Indexation.IsElementExisting(tmp.MusicPart.Musics.First().Author, Element.Author))
            {
                string path = Path.Combine("c:\\AllMusics", tmp.MusicPart.Musics[0].Author.Name);
                Directory.CreateDirectory(path);
                ServerMusics.Add(new Author(tmp.MusicPart.Musics[0].Author.Name,path));
            }

            if (Indexation.IsElementExisting(tmp.MusicPart, Element.Album))
            {
                if (Indexation.IsElementExisting(tmp.MusicPart.Musics.First(), Element.Music))
                {
                    return false;
                }
                else
                {
                    string path = Path.Combine(GetElementPath(tmp.MusicPart.MID, Element.Album), tmp.MusicPart.Musics[0].Title + tmp.MusicPart.Musics[0].Format);
                    System.IO.File.WriteAllBytes(path, tmp.MusicPart.Musics.First().FileBinary);
                    MusicsInfo.SaveMusicInfo(tmp.MusicPart.Musics.First());
                    foreach (var a in ServerMusics)
                    {
                        foreach (var al in a.Albums)
                        {
                            if (al.MID == tmp.MusicPart.MID)
                            {
                                tmp.MusicPart.Musics[0].FileBinary = null;
                                tmp.MusicPart.Musics[0].ServerPath = path;
                                tmp.MusicPart.Musics[0].Author = a;
                                tmp.MusicPart.Musics[0].Album = al;
                                al.Add(tmp.MusicPart.Musics[0]);
                                return true;
                            }
                        }
                    }
                }
            }
            else
            {
                string path = Path.Combine(GetElementPath(tmp.MusicPart.Musics.First().Author.MID, Element.Author), string.Join("", tmp.MusicPart.Name.Split(Path.GetInvalidFileNameChars())));

                Directory.CreateDirectory(path);
                string MusicPath = Path.Combine(path, tmp.MusicPart.Musics[0].Title + tmp.MusicPart.Musics[0].Format);
                System.IO.File.WriteAllBytes(MusicPath, tmp.MusicPart.Musics.First().FileBinary);
                MusicsInfo.SaveMusicInfo(tmp.MusicPart.Musics.First());
                foreach (var a in ServerMusics)
                {
                    if (a.MID == tmp.MusicPart.Musics[0].Author.MID)
                    {
                        tmp.MusicPart.Musics[0].FileBinary = null;
                        tmp.MusicPart.Musics[0].ServerPath = MusicPath;
                        tmp.MusicPart.Musics[0].Author = a;

                        Album tmpAl = new Album(a, tmp.MusicPart.Name, path);
                        tmpAl.Add(tmp.MusicPart.Musics[0]);
                        tmpAl.Musics[0].Album = tmpAl;
                        a.Albums.Add(tmpAl);
                        return true;
                    }
                }
            }
            return false;
        }

        public static string GetElementPath(string ID, Element type)
        {
            switch (type)
            {
                case Element.Author:
                    foreach (var a in ServerMusics)
                    {
                        if (a.MID == ID)
                        {
                            return a.ServerPath;
                        }
                    }
                    break;
                case Element.Album:
                    foreach (var a in ServerMusics)
                    {
                        foreach (var al in a.Albums)
                        {
                            if (ID == al.MID)
                            {
                                return al.ServerPath;
                            }
                        }
                    }
                    break;
                case Element.Music:
                    foreach (var a in GetAllMusics())
                    {
                        if (ID == a.MID)
                        {
                            return a.ServerPath;
                        }
                    }
                    break;
            }
            return null;
        }
    }
}
