namespace Utility.Network
{
    public interface IPacket
    {
        string SenderUID { get; set; }
        bool IsFromServer { get; set; }
    }
}
