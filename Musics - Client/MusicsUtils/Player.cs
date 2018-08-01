using System.IO;
using WMPLib;
using Utility.Musics;

namespace Musics___Client
{
    public class Player
    {
        public WindowsMediaPlayer player = new WindowsMediaPlayer();

        public void PlayMusic(Music music)
        {
            player.controls.stop();
            player.close();

            if (!Directory.Exists(@"c:\MusicsFiles"))
            {
                Directory.CreateDirectory(@"c:\MusicsFiles");
            }
                
            string path = @"c:\MusicsFiles\" + music.Title + music.Format;

            if (!File.Exists(path))
            {
                File.WriteAllBytes(path, music.FileBinary);
            }
            
            player.URL = path;
            player.controls.play();
        }

        public long GetMusiclength()
        {
            FileInfo fileInfo = new FileInfo(player.URL);
            return fileInfo.Length;
        }
    }
}
