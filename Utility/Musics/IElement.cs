using System;

namespace Utility.Musics
{
    public interface IElement
    {
        ElementType Type { get; set; }
        string MID { get; set; }
        string Name { get; }
    }

     
}
