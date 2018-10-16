using System.IO;
using Utility.Musics;
using WMPLib;

namespace ControlLibrary
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

            string path = @"c:\MusicsFiles\" + string.Join("_", music.Title.Split(Path.GetInvalidFileNameChars())) + music.Format;

            if (!File.Exists(path))
            {
                File.WriteAllBytes(path, music.FileBinary);
            }

            player.URL = path;
            player.controls.play();
        }

        public long GetMusiclength()
            => new FileInfo(player.URL).Length;
    }
}
