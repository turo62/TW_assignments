using System;
using System.Collections.Generic;
using System.Drawing;
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
        private ListViewColumnSorter lvwColumnSorter;

        public SanityArchiver()
        {
            InitializeComponent();

            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;

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
            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                ListViewItem item = new ListViewItem(file.Name, 1);
                ListViewItem.ListViewSubItem[] subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, file.Extension.Substring(1)),
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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
            }

            ListFiles(myDirInfo);
        }

        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = textBox3.Text;
            GetPathByFileName(fileName);
            FileOperations myDisplay = new FileOperations(mySelection.FullName);

            this.Hide();
            myDisplay.Closed += (s, args) => this.Close();
            myDisplay.Show();
        }

        private void SanityArchiver_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void ListView1_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView1.GetItemAt(e.X, e.Y);

            if (item != null && item.Selected)
            {
                this.listView1.DoDragDrop(this.listView1.SelectedItems, DragDropEffects.Move);
            }           
        }

        private void ListView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void TreeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void TreeView1_DragDrop(object sender, DragEventArgs e)
        {
            textBox3.Text = null;
            TreeNode nodeToDropIn = this.treeView1.GetNodeAt(this.treeView1.PointToClient(new Point(e.X, e.Y)));
            if (nodeToDropIn == null) { return; }

            string myTarget = FileOperations.TargetDirPath(nodeToDropIn);

            ListView.SelectedListViewItemCollection lvi = (ListView.SelectedListViewItemCollection)e.Data.GetData("System.Windows.Forms.ListView+SelectedListViewItemCollection");
           
            foreach (ListViewItem file in lvi)
            {
                GetPathByFileName(file.Text);
                string fileName = mySelection.FullName;
                string destFile = System.IO.Path.Combine(myTarget, mySelection.Name);
                System.IO.File.Copy(fileName, destFile, true);
                if (!ModifierKeys.HasFlag(Keys.Control))
                {
                    System.IO.File.Delete(fileName);
                }
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView1.Sort();
        }
    }
}
