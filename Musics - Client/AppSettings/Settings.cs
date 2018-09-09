namespace Musics___Client.AppSettings
{
    public class Settings
    {
        public string HueIP { get; set; }
        public string HueKey { get; set; }
        public string ServerIp { get; set; }

        public Settings(string HueIp,string Huekey,string Serverip)
        {
            HueIP = HueIp;
            HueKey = Huekey;
            ServerIp = Serverip;
        }
    }
}
