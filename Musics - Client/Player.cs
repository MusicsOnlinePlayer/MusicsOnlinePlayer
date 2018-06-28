using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using WMPLib;
using Utility;

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
                Directory.CreateDirectory(@"c:\MusicsFiles");

            //File.Create(@"c:\MusicsFiles\20030720.mp3");

            string path = @"c:\MusicsFiles\" + music.Title + music.Format;

            

            File.WriteAllBytes(path, music.FileBinary);

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
