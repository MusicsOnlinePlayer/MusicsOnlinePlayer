using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musics___Client.API
{
    public class Services
    {
        public SearchServices Search;
        public EditMusicsServices EditMusics;
        public RateServices RateServices;
        public PlaylistServices PlaylistServices;

        public void Init()
        {
            Search = new SearchServices();
            EditMusics = new EditMusicsServices();
            RateServices = new RateServices();
            PlaylistServices = new PlaylistServices();
        }
    }
}
