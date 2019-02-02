using Musics___Client.AppSettings;
using System;
using System.Windows.Forms;

namespace Musics___Client
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationSettings.Setup();
            Application.Run(new Client());

            // Application.Run(new Client());
            //Application.Run(new LoginPage());
            //
        }

     
    }
}
