using System.Collections.Generic;
using System.IO; 
using Utility.Musics;
using WMPLib;

namespace ControlLibrary
{
    public class Player 
    {
        public WindowsMediaPlayer player = new WindowsMediaPlayer();

        
        private readonly Dictionary<string, string> Cache = new Dictionary<string, string>();
        public Player()
        {
          
            InitializeCacheDirectory(); 
        }

        private void InitializeCacheDirectory()
        {
            if (!Directory.Exists(@"c:\MusicsFiles"))
                Directory.CreateDirectory(@"c:\MusicsFiles");
        }
        public void PlayMusic(Music music)
        {
            
            player.controls.stop();
            player.close();

            AddToCache(music);

            player.URL = Cache[music.MID];
            player.controls.play();
        }

        public long GetMusiclength()  => new FileInfo(player.URL).Length;

        public bool IsInCache(Music music) => IsInCache(music.MID);
        public bool IsInCache(string MID) => Cache.ContainsKey(MID);

        
        private void AddToCache(Music music)
        {
            if (!IsInCache(music))
            {
                var path = GeneratePath(music);
                AddToCache(music, path);
                WriteInFile(music, path);
            }
        }
        private void AddToCache(Music music, string path) => Cache[music.MID] = path;
        private string GeneratePath(Music music) => @"c:\MusicsFiles\" + string.Join("_", music.Title.Split(Path.GetInvalidFileNameChars())) + music.Format;
        private void WriteInFile(Music music, string path) => File.WriteAllBytes(path, music.FileBinary);
    }
}
