using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sanity_Archiver
{
    public partial class FileOperations : Form
    {
        //string fileName;
        internal FileOperations(string fileName)
        {
            InitializeComponent();
            textBox1.Text = File.ReadAllText(fileName, Encoding.UTF8);
        }

        private void TextDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();

            SanityArchiver newArchiver = new SanityArchiver();
            newArchiver.Closed += (s, args) => this.Close();
            newArchiver.ShowDialog();
        }

        internal static string TargetDirPath(TreeNode targetNode)
        {
            string targetPath = null;
            if (targetNode == null) { return null; }

            while (targetNode.Level > 0)
            {
                if (targetPath == null)
                {
                    targetPath = targetNode.Text;
                }
                else if (targetNode.Level != 0)
                {
                    targetPath = targetNode.Text + @"\" + targetPath;
                }

                targetNode = targetNode.Parent;

                if (targetNode.Level == 0)
                {
                    targetPath = targetNode.Text + targetPath;
                }

            }
            return targetPath;
        }
    }
}
