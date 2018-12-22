    using System.Collections.Generic;
using System.Net.Sockets;
using System.Linq;
using Musics___Server.Usersinfos;
using Musics___Server.MusicsManagement;
using Musics___Server.Network;
using Musics___Server.Commands;
using Utility.Network.Users;
using Utility.Network;
using Utility.Network.Dialog;
using Utility.Musics;
using Utility.Network.Dialog.Rating;
using Utility.Network.Dialog.Edits;
using Utility.Network.Dialog.Uploads;
using Utility.Network.Dialog.Authentification;
using Musics___Server.Services;

namespace Musics___Server
{
    class Program
    {
        public static Server MyServer { get; } = new Server();
        public static ServerComHandler ServerCom = new ServerComHandler();

        public static Service AllServices;

        static void Main(string[] args)
        {
            MyServer.Setup(new System.Net.IPEndPoint(System.Net.IPAddress.Any,2003));

            Indexation.InitRepository();

            MyServer.Log.Info("Indexation of all musics....  ");
            MyServer.Log.Info(Indexation.Do(Properties.Settings.Default.UseMultiThreading) + "Musics");
            MyServer.Log.Info("Indexation done.");
            //Indexation.ServerMusics[0].Albums[0].Musics.First().Tags[0] = new Utility.Musics.Tags.Tag("test");
            Indexation.SaveAllInfos();

            AllServices = new Service();
            AllServices.SetupServices();

            CommandLineInterpreter.Instance.Start();

            MyServer.Log.Info("Saving music info ... ");
            Indexation.SaveAllInfos();
            MyServer.Log.Info("Done.");
        }

        public static void PromoteUser(string UID, Rank rank)
        {
            UsersInfos.SetRankOfUser(UID, rank);
            if (MyServer.Clients.IsConnected(UID))
            {
                var userUpdated = UsersInfos.GetUser(UID);
                new EditUserReport(true, userUpdated).Send(MyServer.Clients.GetSocket(UID));
            }
        }
    }
}