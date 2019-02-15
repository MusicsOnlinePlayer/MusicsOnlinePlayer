using Utility.Network.Tracker.Identity;

namespace Utility.Musics
{
    public interface IElement
    {
        ElementType Type { get; set; }
        string MID { get; set; }
        string Name { get; }
        ServerIdentity Provider { get; set; }
        byte[] Image { get; set; }
    }    
}
