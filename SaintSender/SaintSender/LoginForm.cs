using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaintSender
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtMail.Text = "Type E-mail address";
            txtPass.Text = "Type your password";
        }

        private void txtMail_Enter(object sender, EventArgs e)
        {
            if (txtMail.Text == "Type E-mail address") txtMail.Clear();
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Type your password") txtPass.Clear();
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMail.Text) || string.IsNullOrEmpty(txtPass.Text))
                MessageBox.Show("Neither E-mail address nor Password can be empty!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else if (!DataService.IsValidMail(txtMail.Text))
                MessageBox.Show("Please, type valid E-mail address!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (rememberChk.Checked) DataService.SerializeUserData(txtMail.Text, txtPass.Text);
                {
                    MailboxService service = new MailboxService("imap.gmail.com", new UserData(txtMail.Text, txtPass.Text));

                    if (service.IsAuthenticated())
                    {
                        MessageBox.Show("You won :)");
                        new MainForm(service).Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Authentication error! Please, check E-mail and Password again!", "Authentication error!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }

        }
    }
}
