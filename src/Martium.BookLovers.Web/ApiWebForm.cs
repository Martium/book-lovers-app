using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Martium.BookLovers.Api.Client;
using Martium.BookLovers.Api.Contracts.Request;
using Martium.BookLovers.Api.Contracts.Response;
using Martium.BookLovers.Web.Service;

namespace Martium.BookLovers.Web
{
    public partial class ApiWebForm : Form
    {
        private readonly AuthorsApiClient _authorsApiClient;

        private readonly BooksApiClient _booksApiClient;

        private readonly MessageDialogService _messageDialogService;

        private  List<AuthorReadModel> _getAllAuthors;

        private List<BookReadModel> _getAllBooks;

        private const int TextBoxMaxLength = 100;

        private const string AuthorIdMustBeProvided = "Author id must be provided";

        private const string BookIdMustBeProvided = "Book id must be provided";

        public ApiWebForm()
        {
            InitializeComponent();

            _messageDialogService = new MessageDialogService();

            _authorsApiClient = new AuthorsApiClient();

            _booksApiClient = new BooksApiClient();

            _getAllAuthors = new List<AuthorReadModel>();

            _getAllBooks = new List<BookReadModel>();

            SetComboBoxesControl();

            SetTextBoxLengths();
        }

        private void GetAllAuthorsButton_Click(object sender, EventArgs e)
        {
            ClearAuthorComboBox();

             _getAllAuthors = _authorsApiClient.GetAuthors();

            if (_getAllAuthors != null)
            {
                foreach (var allAuthor in _getAllAuthors)
                {
                    AuthorIdComboBox.Items.Add(allAuthor.Id.ToString());
                    AuthorFirstNameComboBox.Items.Add(allAuthor.FirstName);
                    AuthorLastNameComboBox.Items.Add(allAuthor.LastName);
                }

                DisplayFirstElementInAuthorComboBoxes();
            }
        }

        private void AuthorIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(AuthorIdComboBox.Text);

            AuthorFirstNameComboBox.Text = _getAllAuthors.Find(a => a.Id == id).FirstName;
            AuthorLastNameComboBox.Text = _getAllAuthors.Find(a => a.Id == id).LastName;

        }
       

        private void GetAuthorByIdButton_Click(object sender, EventArgs e)
        {
            bool isAuthorIdTextBoxIsNullOrWhiteSpace = CheckTextBoxIsNullOrWhiteSpace(AuthorIdTextBox, AuthorIdMustBeProvided);

            if (isAuthorIdTextBoxIsNullOrWhiteSpace)
            {
                return;
            }

            int id = int.Parse(AuthorIdTextBox.Text);

            var getAuthor = _authorsApiClient.GetAuthor(id);

            if (getAuthor != null)
            {
                AuthorFirstNameTextBox.Text = getAuthor.FirstName;
                AuthorLastNameTextBox.Text = getAuthor.LastName;
            }
            else
            {
                _messageDialogService.ShowErrorMessage("Author Not found ");
            }
        }

        private void AuthorIdTextBox_TextChanged(object sender, EventArgs e)
        {
            AuthorIdTextBox.BackColor = default;
            ForceTextBoxToBeNumber(AuthorIdTextBox);
        }

        private void AuthorFirstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            AuthorFirstNameTextBox.BackColor = default;
        }

        private void AuthorLastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            AuthorLastNameTextBox.BackColor = default;
        }

        private void CreateNewAuthorButton_Click(object sender, EventArgs e)
        {
            bool isAuthorFirstNameTextBoxIsNullOrWhiteSpace =
                CheckTextBoxIsNullOrWhiteSpace(AuthorFirstNameTextBox, "Author First name must be provided");
            bool isAuthorLastNameTextBoxIsNullOrWhiteSpace =
                CheckTextBoxIsNullOrWhiteSpace(AuthorLastNameTextBox, "Author Last name must be provided");

            if (isAuthorFirstNameTextBoxIsNullOrWhiteSpace || isAuthorLastNameTextBoxIsNullOrWhiteSpace)
            {
                return;
            }

            AuthorModel newAuthor = GetAuthorInfoFromTextBoxes();

            bool isCreated = _authorsApiClient.CreateNewAuthor(newAuthor);

            ShowOperationMessage(isCreated, "New Author Created successfully");
            
        }

        private void UpdateAuthorButton_Click(object sender, EventArgs e)
        {
            bool isAuthorIdTextBoxIsNullOrWhiteSpace = CheckTextBoxIsNullOrWhiteSpace(AuthorIdTextBox, AuthorIdMustBeProvided);
            bool isAuthorFirstNameTextBoxIsNullOrWhiteSpace =
                CheckTextBoxIsNullOrWhiteSpace(AuthorFirstNameTextBox, "Author First name must be provided");
            bool isAuthorLastNameTextBoxIsNullOrWhiteSpace =
                CheckTextBoxIsNullOrWhiteSpace(AuthorLastNameTextBox, "Author Last name must be provided");

            if (isAuthorIdTextBoxIsNullOrWhiteSpace || isAuthorFirstNameTextBoxIsNullOrWhiteSpace || isAuthorLastNameTextBoxIsNullOrWhiteSpace)
            {
                return;
            }

            int id = int.Parse(AuthorIdTextBox.Text);

            AuthorModel updateAuthor = GetAuthorInfoFromTextBoxes();

            bool isUpdated = _authorsApiClient.UpdateAuthorById(updateAuthor, id);

            ShowOperationMessage(isUpdated, "Updated Successful");

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            bool isAuthorIdTextBoxIsNullOrWhiteSpace = CheckTextBoxIsNullOrWhiteSpace(AuthorIdTextBox, AuthorIdMustBeProvided);

            if (isAuthorIdTextBoxIsNullOrWhiteSpace)
            {
                return;
            }

            int id = int.Parse(AuthorIdTextBox.Text);

            bool isDeleted = _authorsApiClient.DeleteAuthorById(id);

            ShowOperationMessage(isDeleted, "Deleted Successful");
        }

        private void GetAllBooksButton_Click(object sender, EventArgs e)
        {
            ClearBookComboBoxes();

            int? authorId = null;

            if (!string.IsNullOrWhiteSpace(BookAuthorIdTextBox.Text))
            {
                authorId = int.Parse(BookAuthorIdTextBox.Text);
            }

            _getAllBooks = _booksApiClient.GetBooks(authorId);

            if (_getAllBooks != null)
            {
                foreach (var books in _getAllBooks)
                {
                    BookIdComboBox.Items.Add(books.Id);
                    BookAuthorIdComboBox.Items.Add(books.AuthorId);
                    BookNameComboBox.Items.Add(books.BookName);
                    ReleaseYearComboBox.Items.Add(books.ReleaseYear);
                }
            }

            DisplayFirstElementInBooksComboBoxes();
        }

        private void BookIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(BookIdComboBox.Text);

            BookAuthorIdComboBox.Text = _getAllBooks.Find(b => b.Id == id).AuthorId.ToString();
            BookNameComboBox.Text = _getAllBooks.Find(b => b.Id == id).BookName;
            ReleaseYearComboBox.Text = _getAllBooks.Find(b => b.Id == id).ReleaseYear.ToString();
            
        }

        private void BookIdTextBox_TextChanged(object sender, EventArgs e)
        {
            BookIdTextBox.BackColor = default;
            ForceTextBoxToBeNumber(BookIdTextBox);
        }

        private void BookAuthorIdTextBox_TextChanged(object sender, EventArgs e)
        {
            BookAuthorIdTextBox.BackColor = default;
            ForceTextBoxToBeNumber(BookAuthorIdTextBox);
        }

        private void BookNameTextBox_TextChanged(object sender, EventArgs e)
        {
            BookNameTextBox.BackColor = default;
        }

        private void ReleaseYearTextBox_TextChanged(object sender, EventArgs e)
        {
            ReleaseYearTextBox.BackColor = default;
            ForceTextBoxToBeNumber(ReleaseYearTextBox);
        }

        private void GetBookByIdButton_Click(object sender, EventArgs e)
        {
            bool isBookIdTextBoxIsNullOrWhiteSpace =
                CheckTextBoxIsNullOrWhiteSpace(BookIdTextBox, BookIdMustBeProvided);

            if (isBookIdTextBoxIsNullOrWhiteSpace)
            {
                return;
            }

            int id = int.Parse(BookIdTextBox.Text);

            var getBook = _booksApiClient.GetBookByBookId(id);

            if (getBook != null)
            {
                BookAuthorIdTextBox.Text = getBook.AuthorId.ToString();
                BookNameTextBox.Text = getBook.BookName;
                ReleaseYearTextBox.Text = getBook.ReleaseYear.ToString();
            }
            else
            {
                _messageDialogService.ShowErrorMessage("Book not found");
            }
        }

        private void CreateNewBookButton_Click(object sender, EventArgs e)
        {
            bool isBookAuthorIdTextBoxIsNullOrWhiteSpace =
                CheckTextBoxIsNullOrWhiteSpace(BookAuthorIdTextBox, AuthorIdMustBeProvided);
            bool isBookNameTextBoxIsNullOrWhiteSpace =
                CheckTextBoxIsNullOrWhiteSpace(BookNameTextBox, "Book name must be provided");
            bool isReleaseYearTextBoxIsNullOrWhiteSpace =
                CheckTextBoxIsNullOrWhiteSpace(ReleaseYearTextBox, "Year must be provided");

            if (isBookAuthorIdTextBoxIsNullOrWhiteSpace || isBookNameTextBoxIsNullOrWhiteSpace || isReleaseYearTextBoxIsNullOrWhiteSpace)
            {
                return;
            }
            
            BookModel newBook = GetBookInfoFromTextBoxes();

            bool isCreated = _booksApiClient.CreateNewAuthor(newBook);

            ShowOperationMessage(isCreated, "New Book Created successfully");
        }

        private void UpdateBookButton_Click(object sender, EventArgs e)
        {
            bool isBookIdTextBoxIsNullOrWhiteSpace =
                CheckTextBoxIsNullOrWhiteSpace(BookIdTextBox, BookIdMustBeProvided);
            bool isBookAuthorIdTextBoxIsNullOrWhiteSpace =
                CheckTextBoxIsNullOrWhiteSpace(BookAuthorIdTextBox, AuthorIdMustBeProvided);
            bool isBookNameTextBoxIsNullOrWhiteSpace =
                CheckTextBoxIsNullOrWhiteSpace(BookNameTextBox, "Book name must be provided");
            bool isReleaseYearTextBoxIsNullOrWhiteSpace =
                CheckTextBoxIsNullOrWhiteSpace(ReleaseYearTextBox, "Year must be provided");

            if (isBookIdTextBoxIsNullOrWhiteSpace || isBookAuthorIdTextBoxIsNullOrWhiteSpace || isBookNameTextBoxIsNullOrWhiteSpace || isReleaseYearTextBoxIsNullOrWhiteSpace)
            {
                return;
            }

            int id = int.Parse(BookIdTextBox.Text);

            BookModel updateBook = GetBookInfoFromTextBoxes();

            bool isBookUpdated = _booksApiClient.UpdateBookById(updateBook, id);

            ShowOperationMessage(isBookUpdated, "Book updated Successfully");

        }

        private void DeleteBookButton_Click(object sender, EventArgs e)
        {
            bool isBookIdTextBoxIsNullOrWhiteSpace = CheckTextBoxIsNullOrWhiteSpace(BookIdTextBox, BookIdMustBeProvided);

            if (isBookIdTextBoxIsNullOrWhiteSpace)
            {
                return;
            }

            int id = int.Parse(BookIdTextBox.Text);

            bool isDeleted = _booksApiClient.DeleteBookById(id);

            ShowOperationMessage(isDeleted, "Deleted Successful");
        }


        #region Helpers

        private void SetComboBoxesControl()
        {
            AuthorIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            AuthorFirstNameComboBox.Enabled = false;
            AuthorLastNameComboBox.Enabled = false;

            BookIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            BookAuthorIdComboBox.Enabled = false;
            BookNameComboBox.Enabled = false;
            ReleaseYearComboBox.Enabled = false;
        }

        private AuthorModel GetAuthorInfoFromTextBoxes()
        {
            AuthorModel author = new AuthorModel()
            {
                FirstName = AuthorFirstNameTextBox.Text,
                LastName = AuthorLastNameTextBox.Text
            };

            return author;
        }

        private BookModel GetBookInfoFromTextBoxes()
        {
            BookModel book = new BookModel()
            {
                AuthorId = int.Parse(BookAuthorIdTextBox.Text),
                BookName = BookNameTextBox.Text,
                ReleaseYear = int.Parse(ReleaseYearTextBox.Text)
            };

            return book;
        }

        private void ShowOperationMessage(bool isSuccessful, string successMessage)
        {
            const string errorMessage = "Something went wrong";

            if (isSuccessful)
            {
                _messageDialogService.ShowInfoMessage(successMessage);
            }
            else
            {
                _messageDialogService.ShowErrorMessage(errorMessage);
            }
        }

        private void ClearAuthorComboBox()
        {
            AuthorIdComboBox.Items.Clear();
            AuthorFirstNameComboBox.Items.Clear();
            AuthorLastNameComboBox.Items.Clear();
        }

        private void ClearBookComboBoxes()
        {
            BookIdComboBox.Items.Clear();
            BookAuthorIdComboBox.Items.Clear();
            BookNameComboBox.Items.Clear();
            ReleaseYearComboBox.Items.Clear();
        }

        private void DisplayFirstElementInAuthorComboBoxes()
        {
            int id = _getAllAuthors.First().Id;

            AuthorIdComboBox.Text = id.ToString();
            AuthorFirstNameComboBox.Text = _getAllAuthors.Find(a => a.Id == id).FirstName;
            AuthorLastNameComboBox.Text = _getAllAuthors.Find(a => a.Id == id).LastName;
        }

        private void DisplayFirstElementInBooksComboBoxes()
        {
            int id = _getAllBooks.First().Id;

            BookIdComboBox.Text = id.ToString();
            BookAuthorIdComboBox.Text = _getAllBooks.Find(b => b.Id == id).AuthorId.ToString();
            BookNameComboBox.Text = _getAllBooks.Find(b => b.Id == id).BookName;
            ReleaseYearComboBox.Text = _getAllBooks.Find(b => b.Id == id).ReleaseYear.ToString();
        }

        private void SetTextBoxLengths()
        {
            AuthorFirstNameTextBox.MaxLength = TextBoxMaxLength;
            AuthorLastNameTextBox.MaxLength = TextBoxMaxLength;

            BookNameTextBox.MaxLength = TextBoxMaxLength;
        }

        private void ForceTextBoxToBeNumber(TextBox textBox)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, "[^0-9]"))
            {
                _messageDialogService.ShowErrorMessage("text must be number (integer type)");
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private bool CheckTextBoxIsNullOrWhiteSpace(TextBox textBox, string errorMessage)
        {
            bool isNullOrWhiteSpace = false;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                _messageDialogService.ShowErrorMessage(errorMessage);
                textBox.BackColor = Color.Red;
                isNullOrWhiteSpace = true;
            }

            return isNullOrWhiteSpace;
        }


        #endregion

        
    }
}
