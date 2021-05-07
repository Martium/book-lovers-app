namespace Martium.BookLovers.Web
{
    partial class ApiWebForm
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
            this.GetAuthorByIdButton = new System.Windows.Forms.Button();
            this.CreateNewAuthorButton = new System.Windows.Forms.Button();
            this.UpdateAuthorButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AuthorInfoLabel = new System.Windows.Forms.Label();
            this.BooksInfoLabel = new System.Windows.Forms.Label();
            this.BookIdLabel = new System.Windows.Forms.Label();
            this.ReleaseYearLabel = new System.Windows.Forms.Label();
            this.BookNameLabel = new System.Windows.Forms.Label();
            this.BookAuthorIdLabel = new System.Windows.Forms.Label();
            this.BookIdTextBox = new System.Windows.Forms.TextBox();
            this.BookAuthorIdTextBox = new System.Windows.Forms.TextBox();
            this.BookNameTextBox = new System.Windows.Forms.TextBox();
            this.ReleaseYearTextBox = new System.Windows.Forms.TextBox();
            this.BookIdListLabel = new System.Windows.Forms.Label();
            this.BookAuthorIdListLabel = new System.Windows.Forms.Label();
            this.BookIdComboBox = new System.Windows.Forms.ComboBox();
            this.BookAuthorIdComboBox = new System.Windows.Forms.ComboBox();
            this.BookNameListLabel = new System.Windows.Forms.Label();
            this.BookNameComboBox = new System.Windows.Forms.ComboBox();
            this.BookReleaseYearListLabel = new System.Windows.Forms.Label();
            this.ReleaseYearComboBox = new System.Windows.Forms.ComboBox();
            this.GetAllBooksButton = new System.Windows.Forms.Button();
            this.GetBookByIdButton = new System.Windows.Forms.Button();
            this.CreateNewBookButton = new System.Windows.Forms.Button();
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
            // 
            // AuthorLastNameComboBox
            // 
            this.AuthorLastNameComboBox.FormattingEnabled = true;
            this.AuthorLastNameComboBox.Location = new System.Drawing.Point(662, 166);
            this.AuthorLastNameComboBox.Name = "AuthorLastNameComboBox";
            this.AuthorLastNameComboBox.Size = new System.Drawing.Size(219, 21);
            this.AuthorLastNameComboBox.TabIndex = 2;
            // 
            // GetAllAuthorsButton
            // 
            this.GetAllAuthorsButton.Location = new System.Drawing.Point(401, 21);
            this.GetAllAuthorsButton.Name = "GetAllAuthorsButton";
            this.GetAllAuthorsButton.Size = new System.Drawing.Size(88, 26);
            this.GetAllAuthorsButton.TabIndex = 3;
            this.GetAllAuthorsButton.Text = "Get All Authors";
            this.GetAllAuthorsButton.UseVisualStyleBackColor = true;
            this.GetAllAuthorsButton.Click += new System.EventHandler(this.GetAllAuthorsButton_Click);
            // 
            // AuthorIdTextBox
            // 
            this.AuthorIdTextBox.Location = new System.Drawing.Point(109, 47);
            this.AuthorIdTextBox.Name = "AuthorIdTextBox";
            this.AuthorIdTextBox.Size = new System.Drawing.Size(114, 20);
            this.AuthorIdTextBox.TabIndex = 4;
            this.AuthorIdTextBox.TextChanged += new System.EventHandler(this.AuthorIdTextBox_TextChanged);
            // 
            // AuthorFirstNameTextBox
            // 
            this.AuthorFirstNameTextBox.Location = new System.Drawing.Point(109, 83);
            this.AuthorFirstNameTextBox.Name = "AuthorFirstNameTextBox";
            this.AuthorFirstNameTextBox.Size = new System.Drawing.Size(197, 20);
            this.AuthorFirstNameTextBox.TabIndex = 5;
            this.AuthorFirstNameTextBox.TextChanged += new System.EventHandler(this.AuthorFirstNameTextBox_TextChanged);
            // 
            // AuthorLastNameTextBox
            // 
            this.AuthorLastNameTextBox.Location = new System.Drawing.Point(109, 118);
            this.AuthorLastNameTextBox.Name = "AuthorLastNameTextBox";
            this.AuthorLastNameTextBox.Size = new System.Drawing.Size(197, 20);
            this.AuthorLastNameTextBox.TabIndex = 6;
            this.AuthorLastNameTextBox.TextChanged += new System.EventHandler(this.AuthorLastNameTextBox_TextChanged);
            // 
            // AuthorIdLabel
            // 
            this.AuthorIdLabel.AutoSize = true;
            this.AuthorIdLabel.Location = new System.Drawing.Point(52, 50);
            this.AuthorIdLabel.Name = "AuthorIdLabel";
            this.AuthorIdLabel.Size = new System.Drawing.Size(50, 13);
            this.AuthorIdLabel.TabIndex = 7;
            this.AuthorIdLabel.Text = "Author Id";
            // 
            // AuthorFirstNameLabel
            // 
            this.AuthorFirstNameLabel.AutoSize = true;
            this.AuthorFirstNameLabel.Location = new System.Drawing.Point(11, 86);
            this.AuthorFirstNameLabel.Name = "AuthorFirstNameLabel";
            this.AuthorFirstNameLabel.Size = new System.Drawing.Size(91, 13);
            this.AuthorFirstNameLabel.TabIndex = 8;
            this.AuthorFirstNameLabel.Text = "Author First Name";
            // 
            // AuthorLastNameLabel
            // 
            this.AuthorLastNameLabel.AutoSize = true;
            this.AuthorLastNameLabel.Location = new System.Drawing.Point(11, 121);
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
            // GetAuthorByIdButton
            // 
            this.GetAuthorByIdButton.Location = new System.Drawing.Point(495, 21);
            this.GetAuthorByIdButton.Name = "GetAuthorByIdButton";
            this.GetAuthorByIdButton.Size = new System.Drawing.Size(98, 26);
            this.GetAuthorByIdButton.TabIndex = 13;
            this.GetAuthorByIdButton.Text = "Get Author by id";
            this.GetAuthorByIdButton.UseVisualStyleBackColor = true;
            this.GetAuthorByIdButton.Click += new System.EventHandler(this.GetAuthorByIdButton_Click);
            // 
            // CreateNewAuthorButton
            // 
            this.CreateNewAuthorButton.Location = new System.Drawing.Point(599, 21);
            this.CreateNewAuthorButton.Name = "CreateNewAuthorButton";
            this.CreateNewAuthorButton.Size = new System.Drawing.Size(98, 26);
            this.CreateNewAuthorButton.TabIndex = 14;
            this.CreateNewAuthorButton.Text = "New Author\r\n";
            this.CreateNewAuthorButton.UseVisualStyleBackColor = true;
            this.CreateNewAuthorButton.Click += new System.EventHandler(this.CreateNewAuthorButton_Click);
            // 
            // UpdateAuthorButton
            // 
            this.UpdateAuthorButton.Location = new System.Drawing.Point(703, 21);
            this.UpdateAuthorButton.Name = "UpdateAuthorButton";
            this.UpdateAuthorButton.Size = new System.Drawing.Size(98, 26);
            this.UpdateAuthorButton.TabIndex = 15;
            this.UpdateAuthorButton.Text = "Update Author \r\n";
            this.UpdateAuthorButton.UseVisualStyleBackColor = true;
            this.UpdateAuthorButton.Click += new System.EventHandler(this.UpdateAuthorButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(807, 21);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(98, 26);
            this.DeleteButton.TabIndex = 16;
            this.DeleteButton.Text = "Delete Author \r\n";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AuthorInfoLabel
            // 
            this.AuthorInfoLabel.AutoSize = true;
            this.AuthorInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthorInfoLabel.Location = new System.Drawing.Point(12, 9);
            this.AuthorInfoLabel.Name = "AuthorInfoLabel";
            this.AuthorInfoLabel.Size = new System.Drawing.Size(72, 20);
            this.AuthorInfoLabel.TabIndex = 17;
            this.AuthorInfoLabel.Text = "Authors";
            // 
            // BooksInfoLabel
            // 
            this.BooksInfoLabel.AutoSize = true;
            this.BooksInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BooksInfoLabel.Location = new System.Drawing.Point(12, 230);
            this.BooksInfoLabel.Name = "BooksInfoLabel";
            this.BooksInfoLabel.Size = new System.Drawing.Size(59, 20);
            this.BooksInfoLabel.TabIndex = 18;
            this.BooksInfoLabel.Text = "Books";
            // 
            // BookIdLabel
            // 
            this.BookIdLabel.AutoSize = true;
            this.BookIdLabel.Location = new System.Drawing.Point(59, 273);
            this.BookIdLabel.Name = "BookIdLabel";
            this.BookIdLabel.Size = new System.Drawing.Size(44, 13);
            this.BookIdLabel.TabIndex = 19;
            this.BookIdLabel.Text = "Book Id";
            // 
            // ReleaseYearLabel
            // 
            this.ReleaseYearLabel.AutoSize = true;
            this.ReleaseYearLabel.Location = new System.Drawing.Point(8, 358);
            this.ReleaseYearLabel.Name = "ReleaseYearLabel";
            this.ReleaseYearLabel.Size = new System.Drawing.Size(94, 13);
            this.ReleaseYearLabel.TabIndex = 20;
            this.ReleaseYearLabel.Text = "Book release Year";
            // 
            // BookNameLabel
            // 
            this.BookNameLabel.AutoSize = true;
            this.BookNameLabel.Location = new System.Drawing.Point(39, 332);
            this.BookNameLabel.Name = "BookNameLabel";
            this.BookNameLabel.Size = new System.Drawing.Size(63, 13);
            this.BookNameLabel.TabIndex = 21;
            this.BookNameLabel.Text = "Book Name";
            // 
            // BookAuthorIdLabel
            // 
            this.BookAuthorIdLabel.AutoSize = true;
            this.BookAuthorIdLabel.Location = new System.Drawing.Point(53, 303);
            this.BookAuthorIdLabel.Name = "BookAuthorIdLabel";
            this.BookAuthorIdLabel.Size = new System.Drawing.Size(50, 13);
            this.BookAuthorIdLabel.TabIndex = 22;
            this.BookAuthorIdLabel.Text = "Author Id";
            // 
            // BookIdTextBox
            // 
            this.BookIdTextBox.Location = new System.Drawing.Point(109, 270);
            this.BookIdTextBox.Name = "BookIdTextBox";
            this.BookIdTextBox.Size = new System.Drawing.Size(114, 20);
            this.BookIdTextBox.TabIndex = 23;
            this.BookIdTextBox.TextChanged += new System.EventHandler(this.BookIdTextBox_TextChanged);
            // 
            // BookAuthorIdTextBox
            // 
            this.BookAuthorIdTextBox.Location = new System.Drawing.Point(109, 300);
            this.BookAuthorIdTextBox.Name = "BookAuthorIdTextBox";
            this.BookAuthorIdTextBox.Size = new System.Drawing.Size(114, 20);
            this.BookAuthorIdTextBox.TabIndex = 24;
            this.BookAuthorIdTextBox.TextChanged += new System.EventHandler(this.BookAuthorIdTextBox_TextChanged);
            // 
            // BookNameTextBox
            // 
            this.BookNameTextBox.Location = new System.Drawing.Point(108, 329);
            this.BookNameTextBox.Name = "BookNameTextBox";
            this.BookNameTextBox.Size = new System.Drawing.Size(198, 20);
            this.BookNameTextBox.TabIndex = 25;
            this.BookNameTextBox.TextChanged += new System.EventHandler(this.BookNameTextBox_TextChanged);
            // 
            // ReleaseYearTextBox
            // 
            this.ReleaseYearTextBox.Location = new System.Drawing.Point(108, 358);
            this.ReleaseYearTextBox.Name = "ReleaseYearTextBox";
            this.ReleaseYearTextBox.Size = new System.Drawing.Size(114, 20);
            this.ReleaseYearTextBox.TabIndex = 26;
            this.ReleaseYearTextBox.TextChanged += new System.EventHandler(this.ReleaseYearTextBox_TextChanged);
            // 
            // BookIdListLabel
            // 
            this.BookIdListLabel.AutoSize = true;
            this.BookIdListLabel.Location = new System.Drawing.Point(13, 434);
            this.BookIdListLabel.Name = "BookIdListLabel";
            this.BookIdListLabel.Size = new System.Drawing.Size(63, 13);
            this.BookIdListLabel.TabIndex = 27;
            this.BookIdListLabel.Text = "Book Id List";
            // 
            // BookAuthorIdListLabel
            // 
            this.BookAuthorIdListLabel.AutoSize = true;
            this.BookAuthorIdListLabel.Location = new System.Drawing.Point(182, 434);
            this.BookAuthorIdListLabel.Name = "BookAuthorIdListLabel";
            this.BookAuthorIdListLabel.Size = new System.Drawing.Size(69, 13);
            this.BookAuthorIdListLabel.TabIndex = 28;
            this.BookAuthorIdListLabel.Text = "Author Id List";
            // 
            // BookIdComboBox
            // 
            this.BookIdComboBox.FormattingEnabled = true;
            this.BookIdComboBox.Location = new System.Drawing.Point(82, 431);
            this.BookIdComboBox.Name = "BookIdComboBox";
            this.BookIdComboBox.Size = new System.Drawing.Size(77, 21);
            this.BookIdComboBox.TabIndex = 29;
            this.BookIdComboBox.SelectedIndexChanged += new System.EventHandler(this.BookIdComboBox_SelectedIndexChanged);
            // 
            // BookAuthorIdComboBox
            // 
            this.BookAuthorIdComboBox.FormattingEnabled = true;
            this.BookAuthorIdComboBox.Location = new System.Drawing.Point(257, 431);
            this.BookAuthorIdComboBox.Name = "BookAuthorIdComboBox";
            this.BookAuthorIdComboBox.Size = new System.Drawing.Size(77, 21);
            this.BookAuthorIdComboBox.TabIndex = 30;
            // 
            // BookNameListLabel
            // 
            this.BookNameListLabel.AutoSize = true;
            this.BookNameListLabel.Location = new System.Drawing.Point(366, 434);
            this.BookNameListLabel.Name = "BookNameListLabel";
            this.BookNameListLabel.Size = new System.Drawing.Size(82, 13);
            this.BookNameListLabel.TabIndex = 31;
            this.BookNameListLabel.Text = "Book Name List";
            // 
            // BookNameComboBox
            // 
            this.BookNameComboBox.FormattingEnabled = true;
            this.BookNameComboBox.Location = new System.Drawing.Point(454, 431);
            this.BookNameComboBox.Name = "BookNameComboBox";
            this.BookNameComboBox.Size = new System.Drawing.Size(243, 21);
            this.BookNameComboBox.TabIndex = 32;
            // 
            // BookReleaseYearListLabel
            // 
            this.BookReleaseYearListLabel.AutoSize = true;
            this.BookReleaseYearListLabel.Location = new System.Drawing.Point(725, 434);
            this.BookReleaseYearListLabel.Name = "BookReleaseYearListLabel";
            this.BookReleaseYearListLabel.Size = new System.Drawing.Size(111, 13);
            this.BookReleaseYearListLabel.TabIndex = 33;
            this.BookReleaseYearListLabel.Text = "Book release year List";
            // 
            // ReleaseYearComboBox
            // 
            this.ReleaseYearComboBox.FormattingEnabled = true;
            this.ReleaseYearComboBox.Location = new System.Drawing.Point(842, 431);
            this.ReleaseYearComboBox.Name = "ReleaseYearComboBox";
            this.ReleaseYearComboBox.Size = new System.Drawing.Size(77, 21);
            this.ReleaseYearComboBox.TabIndex = 34;
            // 
            // GetAllBooksButton
            // 
            this.GetAllBooksButton.Location = new System.Drawing.Point(401, 266);
            this.GetAllBooksButton.Name = "GetAllBooksButton";
            this.GetAllBooksButton.Size = new System.Drawing.Size(88, 26);
            this.GetAllBooksButton.TabIndex = 35;
            this.GetAllBooksButton.Text = "Get All Books";
            this.GetAllBooksButton.UseVisualStyleBackColor = true;
            this.GetAllBooksButton.Click += new System.EventHandler(this.GetAllBooksButton_Click);
            // 
            // GetBookByIdButton
            // 
            this.GetBookByIdButton.Location = new System.Drawing.Point(495, 266);
            this.GetBookByIdButton.Name = "GetBookByIdButton";
            this.GetBookByIdButton.Size = new System.Drawing.Size(88, 26);
            this.GetBookByIdButton.TabIndex = 36;
            this.GetBookByIdButton.Text = "Get Book by Id";
            this.GetBookByIdButton.UseVisualStyleBackColor = true;
            this.GetBookByIdButton.Click += new System.EventHandler(this.GetBookByIdButton_Click);
            // 
            // CreateNewBookButton
            // 
            this.CreateNewBookButton.Location = new System.Drawing.Point(589, 266);
            this.CreateNewBookButton.Name = "CreateNewBookButton";
            this.CreateNewBookButton.Size = new System.Drawing.Size(108, 26);
            this.CreateNewBookButton.TabIndex = 37;
            this.CreateNewBookButton.Text = "Create New Book";
            this.CreateNewBookButton.UseVisualStyleBackColor = true;
            this.CreateNewBookButton.Click += new System.EventHandler(this.CreateNewBookButton_Click);
            // 
            // ApiWebForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 539);
            this.Controls.Add(this.CreateNewBookButton);
            this.Controls.Add(this.GetBookByIdButton);
            this.Controls.Add(this.GetAllBooksButton);
            this.Controls.Add(this.ReleaseYearComboBox);
            this.Controls.Add(this.BookReleaseYearListLabel);
            this.Controls.Add(this.BookNameComboBox);
            this.Controls.Add(this.BookNameListLabel);
            this.Controls.Add(this.BookAuthorIdComboBox);
            this.Controls.Add(this.BookIdComboBox);
            this.Controls.Add(this.BookAuthorIdListLabel);
            this.Controls.Add(this.BookIdListLabel);
            this.Controls.Add(this.ReleaseYearTextBox);
            this.Controls.Add(this.BookNameTextBox);
            this.Controls.Add(this.BookAuthorIdTextBox);
            this.Controls.Add(this.BookIdTextBox);
            this.Controls.Add(this.BookAuthorIdLabel);
            this.Controls.Add(this.BookNameLabel);
            this.Controls.Add(this.ReleaseYearLabel);
            this.Controls.Add(this.BookIdLabel);
            this.Controls.Add(this.BooksInfoLabel);
            this.Controls.Add(this.AuthorInfoLabel);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.UpdateAuthorButton);
            this.Controls.Add(this.CreateNewAuthorButton);
            this.Controls.Add(this.GetAuthorByIdButton);
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
            this.Name = "ApiWebForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Api Web Form";
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
        private System.Windows.Forms.Button GetAuthorByIdButton;
        private System.Windows.Forms.Button CreateNewAuthorButton;
        private System.Windows.Forms.Button UpdateAuthorButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Label AuthorInfoLabel;
        private System.Windows.Forms.Label BooksInfoLabel;
        private System.Windows.Forms.Label BookIdLabel;
        private System.Windows.Forms.Label ReleaseYearLabel;
        private System.Windows.Forms.Label BookNameLabel;
        private System.Windows.Forms.Label BookAuthorIdLabel;
        private System.Windows.Forms.TextBox BookIdTextBox;
        private System.Windows.Forms.TextBox BookAuthorIdTextBox;
        private System.Windows.Forms.TextBox BookNameTextBox;
        private System.Windows.Forms.TextBox ReleaseYearTextBox;
        private System.Windows.Forms.Label BookIdListLabel;
        private System.Windows.Forms.Label BookAuthorIdListLabel;
        private System.Windows.Forms.ComboBox BookIdComboBox;
        private System.Windows.Forms.ComboBox BookAuthorIdComboBox;
        private System.Windows.Forms.Label BookNameListLabel;
        private System.Windows.Forms.ComboBox BookNameComboBox;
        private System.Windows.Forms.Label BookReleaseYearListLabel;
        private System.Windows.Forms.ComboBox ReleaseYearComboBox;
        private System.Windows.Forms.Button GetAllBooksButton;
        private System.Windows.Forms.Button GetBookByIdButton;
        private System.Windows.Forms.Button CreateNewBookButton;
    }
}

