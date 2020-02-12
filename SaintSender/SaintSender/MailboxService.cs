using System;
using System.Collections.Generic;
using Limilabs.Client.IMAP;
using Limilabs.Mail;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SaintSender
{
    public class MailboxService
    {
        private string mailServer;
        private int port;
        public UserData userData;
        public int NoofMails { get; set; }

        public MailboxService(string myServer, int myPort, UserData myData)
        {
            this.mailServer = myServer;
            this.port = myPort;
            this.userData = myData;
        }

        public MailboxService(string myServer, UserData myData)
        {
            this.mailServer = myServer;
            this.userData = myData;
        }

        public void GetAllMails(IProgress<IMail> progress, [Optional] FolderInfo folder)
        {
            using (Imap imap = new Imap())
            {
                imap.ConnectSSL(mailServer);
                imap.UseBestLogin(userData.UserMail, userData.Password);

                if(folder == null) { imap.SelectInbox(); }
                else
                {
                    imap.Select(folder);
                }

                List<long> uids = imap.Search(Flag.Unseen);
                NoofMails = uids.Count;
                foreach (long uid in uids)
                {
                    var eml = imap.GetMessageByUID(uid);
                    IMail mail = new MailBuilder().CreateFromEml(eml);

                    progress.Report(mail);
                }
                imap.Close();
            }
        }

        public void GetAllFolders(IProgress<FolderInfo> progress)
        {
            using (Imap imap = new Imap())
            {
                imap.ConnectSSL(mailServer);
                imap.UseBestLogin(userData.UserMail, userData.Password);

                List<FolderInfo> folders = imap.GetFolders();
                //List<FolderInfo> system = folders.FindAll(x => x.Name.StartsWith("[Gmail]"));
                List<FolderInfo> userFolders = folders.FindAll(x => !x.Name.StartsWith("[Gmail]"));

                foreach(FolderInfo userFolder in userFolders)
                {
                    FolderInfo myFolder = userFolder;

                    progress.Report(myFolder);
                }
                imap.Close();
            }
        }

        public bool IsAuthenticated()
        {
            using (Imap imap = new Imap())
                try                
                {
                    imap.ConnectSSL("imap.gmail.com");
                    imap.UseBestLogin(userData.UserMail, userData.Password);

                    return true;
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show("Login error!", e.Message);
                    return false;
                }
                finally
                {
                    imap.Close();
                }
        }
    }
}
