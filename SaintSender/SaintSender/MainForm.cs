using MetroFramework.Forms;
using System;
using System.Windows.Forms;
using Limilabs.Client.IMAP;
using System.Runtime.InteropServices;
using Limilabs.Mail;
using System.Threading.Tasks;

namespace SaintSender
{
    public partial class MainForm : MetroForm
    {
        private MailboxService mailService;
        public MainForm(MailboxService myService)
        {
            InitializeComponent();
            this.mailService = myService;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
                ReloadForm();
        }

        private void ReloadForm([Optional]FolderInfo folder)
        {
            folderView.Items.Clear();
            mailListView.Items.Clear();
            LoadEmailList(folder);
            LoadFolderView();
        }

        private async void LoadFolderView()
        {
            var progress = new Progress<FolderInfo>(folder => LoadFolderViewItem(folder));

            await Task.Factory.StartNew(() => mailService.GetAllFolders(progress), TaskCreationOptions.LongRunning);
        }

        private void LoadFolderViewItem(FolderInfo folder)
        {
            string myFolder = folder.Name;
            ListViewItem item = new ListViewItem(myFolder);
            //item.SubItems.Add(folder.Name);
            folderView.Items.Add(item);
        }

        private async void LoadEmailList(FolderInfo folder)
        {
            var progress = new Progress<IMail>(mail => LoadListViewItem(mail));

            await Task.Factory.StartNew(() => mailService.GetAllMails(progress, folder), TaskCreationOptions.LongRunning);
        }

        private void LoadListViewItem(IMail mail)
        {
            
            listViewProgressBar.Maximum = mailService.NoofMails;
            ListViewItem item = new ListViewItem();
            item.SubItems.Add(mail.Sender.Name.ToString());
            item.SubItems.Add(mail.Subject.ToString());
            item.SubItems.Add(mail.Date.ToString());
            item.SubItems.Add(mail.Attachments.Count.ToString());
            mailListView.Items.Add(item);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
