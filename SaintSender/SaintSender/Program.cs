using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaintSender
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!File.Exists(@"AppData/login.dat"))
            {
                Application.Run(new LoginForm());
                
            }
            else
            {
                UserData user = DataService.DeserializeUserData();
                Application.Run(new MainForm(new MailboxService("imap.gmail.com", user)));
            }
            
        }
    }
}
