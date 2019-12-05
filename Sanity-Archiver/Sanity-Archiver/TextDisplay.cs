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
    public partial class TextDisplay : Form
    {
        //string fileName;
        public TextDisplay(string fileName)
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
    }
}
