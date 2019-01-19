using Musics___Server.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musics___Server.Services
{
    public class Service
    {
        EditService Editservice;
        EditUserService EditUserervice;
        LoginService Loginservice;
        PlaylistService Playlistservice;
        RatesServices Ratesservices;
        RequestsService Requestsservice;
        UploadService Uploadservice;

        public void SetupServices()
        {
            Editservice = new EditService();
            EditUserervice = new EditUserService();
            Loginservice = new LoginService();
            Playlistservice = new PlaylistService();
            Ratesservices = new RatesServices();
            Requestsservice = new RequestsService();
            Uploadservice = new UploadService();

            TrackerXml.Setup();
        }
    }
}
