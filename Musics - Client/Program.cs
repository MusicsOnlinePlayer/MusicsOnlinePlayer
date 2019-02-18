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
        /// 

        static LoginPageForm Loginf;
        static Client Cl;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationSettings.Setup();
            Loginf = new LoginPageForm();
            Loginf.login1.LoginCompleted += Login1_LoginCompleted;
            Application.Run(Loginf);
            
            // Application.Run(new Client());
            //Application.Run(new LoginPage());
            //
        }

        private static void Login1_LoginCompleted(object sender, API.Events.LoginControlEventArgs e)
        {
            Loginf.Hide();
            Cl = new Client(e.CryptedCredentials);
            Cl.FormClosed += Cl_FormClosed;
            Cl.ShowDialog();
            
        }

        private static void Cl_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
    }
}
