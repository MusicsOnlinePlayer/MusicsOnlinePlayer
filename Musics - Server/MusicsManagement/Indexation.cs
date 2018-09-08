using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Musics___Server.MusicsInformation;
using Utility.Musics;
using Utility.Network.Dialog.Uploads;
using System.Threading.Tasks;
using System.Xml;

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
            => System.IO.File.ReadAllBytes(m.ServerPath);

        public static IEnumerable<Music> GetAllMusics()
            => ServerMusics.SelectMany(x => x.Albums).SelectMany(x => x.Musics);

        public static bool IsElementExisting(IElement element)
        {
            switch (element.Type)
            {
                case Element.Author: return ServerMusics.Any(a => a.MID == element.MID);
                case Element.Album: return ServerMusics.SelectMany(x => x.Albums).Any(a => a.MID == element.MID);
                case Element.Music: return MusicsInfo.TryFindMusic(element.MID, out XmlNode node);
                case Element.Playlist: throw new NotImplementedException();
                default: throw new InvalidOperationException();
            }
        }

        public static int DoIndexation()
        {
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

                        Parallel.ForEach(Directory.GetFiles(a), m =>
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
                                     Genre = file.Tag.Genres,
                                     N = file.Tag.Track
                                 };
                                 if (current.Genre.Length == 0)
                                 {
                                     current.Genre = new string[] { "Unknown" };
                                 }
                                 if (MusicsInfo.TryFindMusic(current.MID, out XmlNode node))
                                 {
                                     current.Rating = MusicsInfo.GetMusicInfo(current.MID).Rating;
                                 }

                                 NumberofMusics++;

                                 CurrentArtist.Albums[i].Musics.Add(current);
                             }
                         });
                        CurrentArtist.Albums[i].Musics = (from m in CurrentArtist.Albums[i].Musics orderby m.N select m).ToList();
                        i++;
                    }
                }
                ServerMusics.Add(CurrentArtist);
            }

            return NumberofMusics;
        }

        public static void ModifyElement(IElement originalElement, string newName, string[] genres)
        {
            switch (originalElement.Type)
            {
                case Element.Music:
                    ModifyMusic(originalElement, newName, genres);
                    break;

                case Element.Album:
                    ModifyAlbum(originalElement, newName);
                    break;
                case Element.Author:
                case Element.Playlist:
                    throw new NotImplementedException();
                default:
                    throw new InvalidOperationException();

            }

            //if (originalElement is Author)
            //{
            //    //Author tmpOrigin = Origin as Author;
            //    //foreach (var a in Indexation.ServerMusics)
            //    //{
            //    //    if(tmpOrigin.MID == a.MID)
            //    //    {
            //    //        a.Name = NewName;
            //    //        a.MID = Hash.SHA256Hash(a.Name + Element.Author);

            //    //        //Directory.Move(a.ServerPath, Directory.GetParent(a.ServerPath) + "/" + a.Name);

            //    //        foreach (var al in a.albums)
            //    //        {
            //    //            al.Author = a;
            //    //            foreach(var m in al.Musics)
            //    //            {
            //    //                m.Author = a;
            //    //            }
            //    //        }

            //    //        return;
            //    //    }
            //    //}
            //}
        }
        public static void ModifyMusic(IElement originalElement, string newName, string[] genres)
        {
            Music foundMusic = GetMusic(originalElement);
            if (null != foundMusic)
            {
                foundMusic.Title = newName;
                foundMusic.MID = Hash.SHA256Hash(foundMusic.Title + foundMusic.Author.Name);

                TagLib.File file = TagLib.File.Create(foundMusic.ServerPath);
                file.Tag.Title = foundMusic.Title;

                if (genres != null)
                {
                    foundMusic.Genre = genres;
                    file.Tag.Genres = genres;
                }

                file.Save();

                MusicsInfo.EditMusicsInfo(originalElement.MID, foundMusic);
            }
        }

        public static void ModifyAlbum(IElement originalElement, string newName)
        {
            Album foundAlbum = GetAlbum(originalElement);
            if (null != foundAlbum)
            {
                foundAlbum.Name = newName;
                foundAlbum.MID = Hash.SHA256Hash(foundAlbum.Name + Element.Album);

                Directory.Move(foundAlbum.ServerPath, Directory.GetParent(foundAlbum.ServerPath) + "/" + foundAlbum.Name);
                foundAlbum.Musics.ForEach(m => m.Album = foundAlbum);
            }
        }

        public static void SaveAllInfos()
        {
            MusicsInfo.SaveMusicsInfo(GetAllMusics());
        }

        public static bool AddElement(UploadMusic tmp)
        {
            if (!Indexation.IsElementExisting(tmp.MusicPart.Musics.First().Author ))
            {
                string path = Path.Combine("c:\\AllMusics", tmp.MusicPart.Musics[0].Author.Name);
                Directory.CreateDirectory(path);
                ServerMusics.Add(new Author(tmp.MusicPart.Musics[0].Author.Name, path));
            }

            if (Indexation.IsElementExisting(tmp.MusicPart ))
            {
                if (Indexation.IsElementExisting(tmp.MusicPart.Musics.First() ))
                {
                    return false;
                }
                else
                {
                    string path = Path.Combine(GetElementPath(tmp.MusicPart), tmp.MusicPart.Musics[0].Title + tmp.MusicPart.Musics[0].Format);
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
                string path = Path.Combine(GetElementPath(tmp.MusicPart.Musics.First().Author), string.Join("", tmp.MusicPart.Name.Split(Path.GetInvalidFileNameChars())));

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

        public static Album GetAlbum(IElement element)
            => ServerMusics.SelectMany(x => x.Albums).SingleOrDefault(x => x.MID == element.MID);
        public static Author GetAuthor(IElement element)
            => ServerMusics.SingleOrDefault(x => x.MID == element.MID);
        public static Music GetMusic(IElement element)
            => GetMusicByID(element.MID);
        public static Music GetMusicByID(string MID)
          => GetAllMusics().SingleOrDefault(m => m.MID == MID);

        public static string GetElementPath(IElement element)
        {
            switch (element.Type)
            {
                case Element.Author: return GetAuthor(element)?.ServerPath;
                case Element.Album: return GetAlbum(element)?.ServerPath;
                case Element.Music: return GetMusic(element)?.ServerPath;
                default: throw new InvalidOperationException();
            }
        }
    }
}
