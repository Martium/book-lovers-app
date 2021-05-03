namespace Martium.BookLovers.Web
{
    partial class AuthorForm
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
            this.AuthorIdComboBox = new System.Windows.Forms.ComboBox();
            this.AuthorFirstNameComboBox = new System.Windows.Forms.ComboBox();
            this.AuthorLastNameComboBox = new System.Windows.Forms.ComboBox();
            this.GetAllAuthorsButton = new System.Windows.Forms.Button();
            this.AuthorIdTextBox = new System.Windows.Forms.TextBox();
            this.AuthorFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.AuthorLastNameTextBox = new System.Windows.Forms.TextBox();
            this.AuthorIdLabel = new System.Windows.Forms.Label();
            this.AuthorFirstNameLabel = new System.Windows.Forms.Label();
            this.AuthorLastNameLabel = new System.Windows.Forms.Label();
            this.AuthorIdListLabel = new System.Windows.Forms.Label();
            this.AuthorFirstNameListLabel = new System.Windows.Forms.Label();
            this.AuthorLastNameListLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AuthorIdComboBox
            // 
            this.AuthorIdComboBox.FormattingEnabled = true;
            this.AuthorIdComboBox.Location = new System.Drawing.Point(87, 166);
            this.AuthorIdComboBox.Name = "AuthorIdComboBox";
            this.AuthorIdComboBox.Size = new System.Drawing.Size(77, 21);
            this.AuthorIdComboBox.TabIndex = 0;
            this.AuthorIdComboBox.SelectedIndexChanged += new System.EventHandler(this.AuthorIdComboBox_SelectedIndexChanged);
            // 
            // AuthorFirstNameComboBox
            // 
            this.AuthorFirstNameComboBox.FormattingEnabled = true;
            this.AuthorFirstNameComboBox.Location = new System.Drawing.Point(312, 166);
            this.AuthorFirstNameComboBox.Name = "AuthorFirstNameComboBox";
            this.AuthorFirstNameComboBox.Size = new System.Drawing.Size(209, 21);
            this.AuthorFirstNameComboBox.TabIndex = 1;
            this.AuthorFirstNameComboBox.SelectedIndexChanged += new System.EventHandler(this.AuthorFirstNameComboBox_SelectedIndexChanged);
            // 
            // AuthorLastNameComboBox
            // 
            this.AuthorLastNameComboBox.FormattingEnabled = true;
            this.AuthorLastNameComboBox.Location = new System.Drawing.Point(662, 166);
            this.AuthorLastNameComboBox.Name = "AuthorLastNameComboBox";
            this.AuthorLastNameComboBox.Size = new System.Drawing.Size(219, 21);
            this.AuthorLastNameComboBox.TabIndex = 2;
            this.AuthorLastNameComboBox.SelectedIndexChanged += new System.EventHandler(this.AuthorLastNameComboBox_SelectedIndexChanged);
            // 
            // GetAllAuthorsButton
            // 
            this.GetAllAuthorsButton.Location = new System.Drawing.Point(280, 21);
            this.GetAllAuthorsButton.Name = "GetAllAuthorsButton";
            this.GetAllAuthorsButton.Size = new System.Drawing.Size(88, 26);
            this.GetAllAuthorsButton.TabIndex = 3;
            this.GetAllAuthorsButton.Text = "Get All Authors";
            this.GetAllAuthorsButton.UseVisualStyleBackColor = true;
            this.GetAllAuthorsButton.Click += new System.EventHandler(this.GetAllAuthorsButton_Click);
            // 
            // AuthorIdTextBox
            // 
            this.AuthorIdTextBox.Location = new System.Drawing.Point(109, 21);
            this.AuthorIdTextBox.Name = "AuthorIdTextBox";
            this.AuthorIdTextBox.Size = new System.Drawing.Size(114, 20);
            this.AuthorIdTextBox.TabIndex = 4;
            // 
            // AuthorFirstNameTextBox
            // 
            this.AuthorFirstNameTextBox.Location = new System.Drawing.Point(109, 59);
            this.AuthorFirstNameTextBox.Name = "AuthorFirstNameTextBox";
            this.AuthorFirstNameTextBox.Size = new System.Drawing.Size(114, 20);
            this.AuthorFirstNameTextBox.TabIndex = 5;
            // 
            // AuthorLastNameTextBox
            // 
            this.AuthorLastNameTextBox.Location = new System.Drawing.Point(109, 93);
            this.AuthorLastNameTextBox.Name = "AuthorLastNameTextBox";
            this.AuthorLastNameTextBox.Size = new System.Drawing.Size(114, 20);
            this.AuthorLastNameTextBox.TabIndex = 6;
            // 
            // AuthorIdLabel
            // 
            this.AuthorIdLabel.AutoSize = true;
            this.AuthorIdLabel.Location = new System.Drawing.Point(39, 24);
            this.AuthorIdLabel.Name = "AuthorIdLabel";
            this.AuthorIdLabel.Size = new System.Drawing.Size(50, 13);
            this.AuthorIdLabel.TabIndex = 7;
            this.AuthorIdLabel.Text = "Author Id";
            // 
            // AuthorFirstNameLabel
            // 
            this.AuthorFirstNameLabel.AutoSize = true;
            this.AuthorFirstNameLabel.Location = new System.Drawing.Point(12, 62);
            this.AuthorFirstNameLabel.Name = "AuthorFirstNameLabel";
            this.AuthorFirstNameLabel.Size = new System.Drawing.Size(91, 13);
            this.AuthorFirstNameLabel.TabIndex = 8;
            this.AuthorFirstNameLabel.Text = "Author First Name";
            // 
            // AuthorLastNameLabel
            // 
            this.AuthorLastNameLabel.AutoSize = true;
            this.AuthorLastNameLabel.Location = new System.Drawing.Point(12, 96);
            this.AuthorLastNameLabel.Name = "AuthorLastNameLabel";
            this.AuthorLastNameLabel.Size = new System.Drawing.Size(92, 13);
            this.AuthorLastNameLabel.TabIndex = 9;
            this.AuthorLastNameLabel.Text = "Author Last Name";
            // 
            // AuthorIdListLabel
            // 
            this.AuthorIdListLabel.AutoSize = true;
            this.AuthorIdListLabel.Location = new System.Drawing.Point(12, 169);
            this.AuthorIdListLabel.Name = "AuthorIdListLabel";
            this.AuthorIdListLabel.Size = new System.Drawing.Size(69, 13);
            this.AuthorIdListLabel.TabIndex = 10;
            this.AuthorIdListLabel.Text = "Author Id List";
            // 
            // AuthorFirstNameListLabel
            // 
            this.AuthorFirstNameListLabel.AutoSize = true;
            this.AuthorFirstNameListLabel.Location = new System.Drawing.Point(198, 169);
            this.AuthorFirstNameListLabel.Name = "AuthorFirstNameListLabel";
            this.AuthorFirstNameListLabel.Size = new System.Drawing.Size(108, 13);
            this.AuthorFirstNameListLabel.TabIndex = 11;
            this.AuthorFirstNameListLabel.Text = "Author First name List";
            // 
            // AuthorLastNameListLabel
            // 
            this.AuthorLastNameListLabel.AutoSize = true;
            this.AuthorLastNameListLabel.Location = new System.Drawing.Point(547, 169);
            this.AuthorLastNameListLabel.Name = "AuthorLastNameListLabel";
            this.AuthorLastNameListLabel.Size = new System.Drawing.Size(109, 13);
            this.AuthorLastNameListLabel.TabIndex = 12;
            this.AuthorLastNameListLabel.Text = "Author Last name List";
            // 
            // AuthorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 450);
            this.Controls.Add(this.AuthorLastNameListLabel);
            this.Controls.Add(this.AuthorFirstNameListLabel);
            this.Controls.Add(this.AuthorIdListLabel);
            this.Controls.Add(this.AuthorLastNameLabel);
            this.Controls.Add(this.AuthorFirstNameLabel);
            this.Controls.Add(this.AuthorIdLabel);
            this.Controls.Add(this.AuthorLastNameTextBox);
            this.Controls.Add(this.AuthorFirstNameTextBox);
            this.Controls.Add(this.AuthorIdTextBox);
            this.Controls.Add(this.GetAllAuthorsButton);
            this.Controls.Add(this.AuthorLastNameComboBox);
            this.Controls.Add(this.AuthorFirstNameComboBox);
            this.Controls.Add(this.AuthorIdComboBox);
            this.MaximizeBox = false;
            this.Name = "AuthorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Authors";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox AuthorIdComboBox;
        private System.Windows.Forms.ComboBox AuthorFirstNameComboBox;
        private System.Windows.Forms.ComboBox AuthorLastNameComboBox;
        private System.Windows.Forms.Button GetAllAuthorsButton;
        private System.Windows.Forms.TextBox AuthorIdTextBox;
        private System.Windows.Forms.TextBox AuthorFirstNameTextBox;
        private System.Windows.Forms.TextBox AuthorLastNameTextBox;
        private System.Windows.Forms.Label AuthorIdLabel;
        private System.Windows.Forms.Label AuthorFirstNameLabel;
        private System.Windows.Forms.Label AuthorLastNameLabel;
        private System.Windows.Forms.Label AuthorIdListLabel;
        private System.Windows.Forms.Label AuthorFirstNameListLabel;
        private System.Windows.Forms.Label AuthorLastNameListLabel;
    }
}

