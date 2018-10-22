using System.Drawing;
using System.IO;

namespace ControlLibrary
{
    public class Tags
    {
        public static Image GetMetaImage(string MusicPath)
        {
            TagLib.File f = new TagLib.Mpeg.AudioFile(MusicPath);

            var pic = f.Tag.Pictures[0];
            using (var ms = new MemoryStream(pic.Data.Data))
            {
                var image = Image.FromStream(ms);
                return image;
            }
        }
    }
}
