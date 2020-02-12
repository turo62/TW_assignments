namespace SaintSender
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMark_as_Read = new MetroFramework.Controls.MetroButton();
            this.folderView = new MetroFramework.Controls.MetroListView();
            this.txtSearch = new MetroFramework.Controls.MetroTextBox();
            this.mailListView = new MetroFramework.Controls.MetroListView();
            this.markAsRead = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.subject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.attachment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnNew = new MetroFramework.Controls.MetroButton();
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.btnBackUp = new MetroFramework.Controls.MetroButton();
            this.btnRestore = new MetroFramework.Controls.MetroButton();
            this.btnQuit = new MetroFramework.Controls.MetroButton();
            this.listViewProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.folder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnMark_as_Read
            // 
            this.btnMark_as_Read.BackColor = System.Drawing.Color.Fuchsia;
            this.btnMark_as_Read.Location = new System.Drawing.Point(235, 53);
            this.btnMark_as_Read.Name = "btnMark_as_Read";
            this.btnMark_as_Read.Size = new System.Drawing.Size(101, 23);
            this.btnMark_as_Read.TabIndex = 0;
            this.btnMark_as_Read.Text = "Mark as Read";
            this.btnMark_as_Read.UseCustomBackColor = true;
            this.btnMark_as_Read.UseSelectable = true;
            // 
            // folderView
            // 
            this.folderView.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.folderView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.folder});
            this.folderView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.folderView.FullRowSelect = true;
            this.folderView.Location = new System.Drawing.Point(9, 12);
            this.folderView.Name = "folderView";
            this.folderView.OwnerDraw = true;
            this.folderView.Size = new System.Drawing.Size(220, 568);
            this.folderView.TabIndex = 1;
            this.folderView.UseCompatibleStateImageBehavior = false;
            this.folderView.UseSelectable = true;
            this.folderView.View = System.Windows.Forms.View.Details;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.txtSearch.CustomButton.Image = null;
            this.txtSearch.CustomButton.Location = new System.Drawing.Point(386, 1);
            this.txtSearch.CustomButton.Name = "";
            this.txtSearch.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSearch.CustomButton.TabIndex = 1;
            this.txtSearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSearch.CustomButton.UseSelectable = true;
            this.txtSearch.CustomButton.Visible = false;
            this.txtSearch.Lines = new string[0];
            this.txtSearch.Location = new System.Drawing.Point(477, 53);
            this.txtSearch.MaxLength = 32767;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSearch.SelectedText = "";
            this.txtSearch.SelectionLength = 0;
            this.txtSearch.SelectionStart = 0;
            this.txtSearch.ShortcutsEnabled = true;
            this.txtSearch.Size = new System.Drawing.Size(408, 23);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.UseCustomBackColor = true;
            this.txtSearch.UseSelectable = true;
            this.txtSearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mailListView
            // 
            this.mailListView.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.mailListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.markAsRead,
            this.sender,
            this.subject,
            this.date,
            this.attachment});
            this.mailListView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.mailListView.FullRowSelect = true;
            this.mailListView.Location = new System.Drawing.Point(235, 82);
            this.mailListView.Name = "mailListView";
            this.mailListView.OwnerDraw = true;
            this.mailListView.Size = new System.Drawing.Size(1140, 471);
            this.mailListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.mailListView.TabIndex = 3;
            this.mailListView.UseCompatibleStateImageBehavior = false;
            this.mailListView.UseCustomBackColor = true;
            this.mailListView.UseSelectable = true;
            this.mailListView.View = System.Windows.Forms.View.Details;
            // 
            // markAsRead
            // 
            this.markAsRead.Text = "Mark read/unread";
            this.markAsRead.Width = 77;
            // 
            // sender
            // 
            this.sender.Text = "Sender";
            this.sender.Width = 240;
            // 
            // subject
            // 
            this.subject.Text = "Subject";
            this.subject.Width = 550;
            // 
            // date
            // 
            this.date.Text = "Date";
            this.date.Width = 197;
            // 
            // attachment
            // 
            this.attachment.Text = "Attachment";
            this.attachment.Width = 210;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Fuchsia;
            this.btnNew.Location = new System.Drawing.Point(235, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "New mail";
            this.btnNew.UseCustomBackColor = true;
            this.btnNew.UseSelectable = true;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Fuchsia;
            this.btnSearch.Location = new System.Drawing.Point(860, 53);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseCustomBackColor = true;
            this.btnSearch.UseSelectable = true;
            // 
            // btnBackUp
            // 
            this.btnBackUp.BackColor = System.Drawing.Color.Fuchsia;
            this.btnBackUp.Location = new System.Drawing.Point(344, 12);
            this.btnBackUp.Name = "btnBackUp";
            this.btnBackUp.Size = new System.Drawing.Size(101, 23);
            this.btnBackUp.TabIndex = 6;
            this.btnBackUp.Text = "Back Up";
            this.btnBackUp.UseCustomBackColor = true;
            this.btnBackUp.UseSelectable = true;
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.Fuchsia;
            this.btnRestore.Location = new System.Drawing.Point(370, 53);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 7;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseCustomBackColor = true;
            this.btnRestore.UseSelectable = true;
            // 
            // btnQuit
            // 
            this.btnQuit.BackColor = System.Drawing.Color.Navy;
            this.btnQuit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnQuit.Location = new System.Drawing.Point(834, 12);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(101, 23);
            this.btnQuit.TabIndex = 8;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseCustomBackColor = true;
            this.btnQuit.UseCustomForeColor = true;
            this.btnQuit.UseSelectable = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // listViewProgressBar
            // 
            this.listViewProgressBar.Location = new System.Drawing.Point(235, 569);
            this.listViewProgressBar.Name = "listViewProgressBar";
            this.listViewProgressBar.Size = new System.Drawing.Size(700, 11);
            this.listViewProgressBar.TabIndex = 9;
            // 
            // folder
            // 
            this.folder.Text = "Folder Name";
            this.folder.Width = 218;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 593);
            this.Controls.Add(this.listViewProgressBar);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnBackUp);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.mailListView);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.folderView);
            this.Controls.Add(this.btnMark_as_Read);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnMark_as_Read;
        private MetroFramework.Controls.MetroListView folderView;
        private MetroFramework.Controls.MetroTextBox txtSearch;
        private MetroFramework.Controls.MetroListView mailListView;
        private System.Windows.Forms.ColumnHeader markAsRead;
        private System.Windows.Forms.ColumnHeader sender;
        private System.Windows.Forms.ColumnHeader subject;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ColumnHeader attachment;
        private MetroFramework.Controls.MetroButton btnNew;
        private MetroFramework.Controls.MetroButton btnSearch;
        private MetroFramework.Controls.MetroButton btnBackUp;
        private MetroFramework.Controls.MetroButton btnRestore;
        private MetroFramework.Controls.MetroButton btnQuit;
        private MetroFramework.Controls.MetroProgressBar listViewProgressBar;
        private System.Windows.Forms.ColumnHeader folder;
    }
}