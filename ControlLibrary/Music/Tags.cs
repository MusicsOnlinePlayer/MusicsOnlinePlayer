using System;
using System.Drawing;
using System.IO;
using TagLib;

namespace ControlLibrary
{
    public class Tags
    {
        public static Image GetMetaImage(string MusicPath)
        {
            TagLib.File f = new TagLib.Mpeg.AudioFile(MusicPath);

            TagLib.IPicture pic = f.Tag.Pictures[0];
            using (MemoryStream ms = new MemoryStream(pic.Data.Data))
            {
                Image image = Image.FromStream(ms);
                return image;
            }
        }
    }
}
