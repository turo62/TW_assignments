using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Sanity_Archiver
{
    public partial class SanityArchiver : Form
    {
        readonly private static string PLACEHOLDER = "...";
        string[] drives;
        //static string actFile;
        readonly SizeCalculator calculateDir = new SizeCalculator();
        readonly private List<FileInfo> myFiles = new List<FileInfo>();
        private DirectoryInfo myDirInfo;
        private FileInfo mySelection;
        Cypherer myCypherer = new Cypherer();

        public SanityArchiver()
        {
            InitializeComponent();
            ListDrives();
        }

        private void ListDrives()
        {
            drives = Environment.GetLogicalDrives();
            foreach (string drive in drives)
            {
                if (Directory.Exists(drive))
                {
                    TreeNode node = new TreeNode(drive);
                    node.Tag = drive;
                    this.treeView1.Nodes.Add(node);
                    node.Nodes.Add(new TreeNode(PLACEHOLDER));
                }
            }
            this.treeView1.BeforeExpand += new TreeViewCancelEventHandler(TreeView_BeforeExpand);
        }

        void TreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == PLACEHOLDER)
                {
                    e.Node.Nodes.Clear();
                    string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());
                    foreach (string dir in dirs)
                    {
                        DirectoryInfo di = new DirectoryInfo(dir);
                        TreeNode node = new TreeNode(di.Name);
                        node.Tag = dir;
                        node.ImageIndex = 1;
                        try
                        {
                            if (di.GetDirectories().GetLength(0) > 0)
                                node.Nodes.Add(null, PLACEHOLDER);
                        }
                        catch (UnauthorizedAccessException)
                        {
                            // TODO: update node images
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "ExplorerForm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            e.Node.Nodes.Add(node);
                        }
                    }
                }
            }
        }

        private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            long size = 0;

            TreeNode newSelected = e.Node;
            textBox2.Text = newSelected.Text;
            listView1.Items.Clear();
            myDirInfo = new DirectoryInfo(newSelected.Tag.ToString());
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            size = calculateDir.CalculateDirectorySize(myDirInfo);
            textBox1.Text = null;
            textBox1.Text = size.ToString() + " MB";

            foreach (DirectoryInfo dir in myDirInfo.GetDirectories())
            {
                item = new ListViewItem(dir.Name, 0);
                subItems = new ListViewItem.ListViewSubItem[]
                    {new ListViewItem.ListViewSubItem(item, "Directory"),
             new ListViewItem.ListViewSubItem(item,
                dir.LastAccessTime.ToShortDateString())};
                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }

            ListFiles(myDirInfo);

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private List<FileInfo> ListFiles(DirectoryInfo nodeDirInfo)
        {
            listView1.Items.Clear();

            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                ListViewItem item = new ListViewItem(file.Name, 1);
                ListViewItem.ListViewSubItem[] subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, "File"),
             new ListViewItem.ListViewSubItem(item,
                file.LastAccessTime.ToShortDateString())};

                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
                myFiles.Add(file);
            }

            return myFiles;
        }

        private void GetPathByFileName(string name)
        {
            foreach (FileInfo file in myDirInfo.GetFiles())
            {
                if (file.Name.Equals(name))
                {
                    mySelection = file;
                }
            }
        }

        private void EncrypteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool crypted = false;
            try
            {
                string fileName = textBox3.Text;
                GetPathByFileName(fileName);
                myCypherer.CompleteCrypt(mySelection.FullName, crypted);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void DecrypteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool crypted = true;

            try
            {
                string fileName = textBox3.Text;
                GetPathByFileName(fileName);
                myCypherer.CompleteCrypt(mySelection.FullName, crypted);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ListView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var item = listView1.SelectedItems[0];
                textBox3.Text = item.Text;
            }

            if (e.Button == MouseButtons.Right)
            {
                ListViewItem item = listView1.GetItemAt(e.X, e.Y);

                if (item != null)
                {
                    item.Selected = true;
                }
            }
        }

        private void CompressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = textBox3.Text;
                GetPathByFileName(fileName);

                Compressor.CompressFile(mySelection);
            }

            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DecompressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = textBox3.Text;
                GetPathByFileName(fileName);

                Compressor.DecompressFile(mySelection);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

            ListFiles(myDirInfo);
        }

        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = textBox3.Text;
            GetPathByFileName(fileName);
            TextDisplay myDisplay = new TextDisplay(mySelection.FullName);

            this.Hide();
            myDisplay.Closed += (s, args) => this.Close();
            myDisplay.Show();
        }

        private void SanityArchiver_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }
    }
}
