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

namespace Serializer
{
    public partial class Serializer : Form
    {
        private int actSerNum;

        public Serializer()
        {
            InitializeComponent();
            RefreshForm(1);
        }

        public void RefreshForm(int serNum)
        {
            Person p = Person.Deserialize(serNum);
            txtName.Text = p.Name;
            txtAddress.Text = p.Address;
            txtPhone.Text = p.Phone;
        }

        private void BtnSave_MouseClick(object sender, MouseEventArgs e)
        {
            int tempNum = GetLatestSerialNo();
            actSerNum = tempNum + 1;
            string output = "";

            if (actSerNum < 100)
            {
                output = @"C:\ForTrials\person" + actSerNum + ".dat";
                Person personToSave = new Person(txtName.Text, txtAddress.Text, txtPhone.Text, DateTime.Now, actSerNum);
                personToSave.Serialize(output);
                MessageBox.Show(txtName.Text + " is saved");

            }
            else
            {
                MessageBox.Show("Maximum number of persons exceeded");
            }
        }

        public int GetLatestSerialNo()
        {
            string path = @"C:\ForTrials";
            int numberOfFiles = 0;

            try
            {
                string[] files = Directory.GetFiles(path);
                
                foreach(string file in files)
                {
                    if(file.Contains("person"))
                    {
                        numberOfFiles = numberOfFiles + 1;
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return numberOfFiles;
        }

        private void BtnFirst_MouseClick(object sender, MouseEventArgs e)
        {
            actSerNum = 1;
            RefreshForm(actSerNum);
        }

        private void BtnLast_MouseClick(object sender, MouseEventArgs e)
        {
            actSerNum = GetLatestSerialNo();
            RefreshForm(actSerNum);
        }

        private void BtnNext_MouseClick(object sender, MouseEventArgs e)
        {
            if(actSerNum == GetLatestSerialNo())
            {
                MessageBox.Show("Next person is not available\nLast person in list displayed");
            }
            else
            {
                actSerNum = actSerNum + 1;
                RefreshForm(actSerNum);
            }            
        }

        private void BtnPrevious_MouseClick(object sender, MouseEventArgs e)
        {
            if(actSerNum == 1)
            {
                MessageBox.Show("No previous person in list. \nFirst person is displayed already");
            }
            else
            {
                actSerNum = actSerNum - 1;
                RefreshForm(actSerNum);
            }            
        }
    }
}
