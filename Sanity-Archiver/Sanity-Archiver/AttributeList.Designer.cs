namespace Sanity_Archiver
{
    partial class AttributeList
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
            this.ReadOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.hiddenCheckBox = new System.Windows.Forms.CheckBox();
            this.archiveCheckBox = new System.Windows.Forms.CheckBox();
            this.encryptedC = new System.Windows.Forms.CheckBox();
            this.notContentIndexedCheckBox = new System.Windows.Forms.CheckBox();
            this.defaultButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReadOnlyCheckBox
            // 
            this.ReadOnlyCheckBox.AutoSize = true;
            this.ReadOnlyCheckBox.Location = new System.Drawing.Point(26, 65);
            this.ReadOnlyCheckBox.Name = "ReadOnlyCheckBox";
            this.ReadOnlyCheckBox.Size = new System.Drawing.Size(95, 21);
            this.ReadOnlyCheckBox.TabIndex = 5;
            this.ReadOnlyCheckBox.Text = "Read-only";
            this.ReadOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // hiddenCheckBox
            // 
            this.hiddenCheckBox.AutoSize = true;
            this.hiddenCheckBox.Location = new System.Drawing.Point(26, 91);
            this.hiddenCheckBox.Name = "hiddenCheckBox";
            this.hiddenCheckBox.Size = new System.Drawing.Size(75, 21);
            this.hiddenCheckBox.TabIndex = 6;
            this.hiddenCheckBox.Text = "Hidden";
            this.hiddenCheckBox.UseVisualStyleBackColor = true;
            // 
            // archiveCheckBox
            // 
            this.archiveCheckBox.AutoSize = true;
            this.archiveCheckBox.Location = new System.Drawing.Point(26, 121);
            this.archiveCheckBox.Name = "archiveCheckBox";
            this.archiveCheckBox.Size = new System.Drawing.Size(77, 21);
            this.archiveCheckBox.TabIndex = 7;
            this.archiveCheckBox.Text = "Archive";
            this.archiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // encryptedC
            // 
            this.encryptedC.AutoSize = true;
            this.encryptedC.Location = new System.Drawing.Point(26, 151);
            this.encryptedC.Name = "encryptedC";
            this.encryptedC.Size = new System.Drawing.Size(94, 21);
            this.encryptedC.TabIndex = 8;
            this.encryptedC.Text = "Encrypted";
            this.encryptedC.UseVisualStyleBackColor = true;
            // 
            // notContentIndexedCheckBox
            // 
            this.notContentIndexedCheckBox.AutoSize = true;
            this.notContentIndexedCheckBox.Location = new System.Drawing.Point(26, 180);
            this.notContentIndexedCheckBox.Name = "notContentIndexedCheckBox";
            this.notContentIndexedCheckBox.Size = new System.Drawing.Size(150, 21);
            this.notContentIndexedCheckBox.TabIndex = 9;
            this.notContentIndexedCheckBox.Text = "NotContentIndexed";
            this.notContentIndexedCheckBox.UseVisualStyleBackColor = true;
            // 
            // defaultButton
            // 
            this.defaultButton.Location = new System.Drawing.Point(51, 12);
            this.defaultButton.Name = "defaultButton";
            this.defaultButton.Size = new System.Drawing.Size(95, 39);
            this.defaultButton.TabIndex = 10;
            this.defaultButton.Text = "Default";
            this.defaultButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(51, 207);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(95, 38);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // AttributeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 281);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.defaultButton);
            this.Controls.Add(this.notContentIndexedCheckBox);
            this.Controls.Add(this.encryptedC);
            this.Controls.Add(this.archiveCheckBox);
            this.Controls.Add(this.hiddenCheckBox);
            this.Controls.Add(this.ReadOnlyCheckBox);
            this.Name = "AttributeList";
            this.Text = "Attributes Changer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ReadOnlyCheckBox;
        private System.Windows.Forms.CheckBox hiddenCheckBox;
        private System.Windows.Forms.CheckBox archiveCheckBox;
        private System.Windows.Forms.CheckBox encryptedC;
        private System.Windows.Forms.CheckBox notContentIndexedCheckBox;
        private System.Windows.Forms.Button defaultButton;
        private System.Windows.Forms.Button saveButton;
    }
}