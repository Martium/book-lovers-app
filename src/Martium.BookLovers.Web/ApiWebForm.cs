using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Martium.BookLovers.Api.Client;
using Martium.BookLovers.Api.Contracts.Request;
using Martium.BookLovers.Api.Contracts.Response;
using Martium.BookLovers.Web.Enums;
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

             if (_getAllAuthors.Count == 0)
             {
                 _messageDialogService.ShowErrorMessage(ErrorsTypes.ThereIsNoAuthors);
                 ClearAllAuthorsTextBoxes();
                 return;
             }

             foreach (var allAuthor in _getAllAuthors)
             {
                 AuthorIdComboBox.Items.Add(allAuthor.Id.ToString());
                 AuthorFirstNameComboBox.Items.Add(allAuthor.FirstName);
                 AuthorLastNameComboBox.Items.Add(allAuthor.LastName);
             }

             DisplayFirstElementInAuthorComboBoxes();
        }

        private void AuthorIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(AuthorIdComboBox.Text);

            AuthorFirstNameComboBox.Text = _getAllAuthors.Find(a => a.Id == id).FirstName;
            AuthorLastNameComboBox.Text = _getAllAuthors.Find(a => a.Id == id).LastName;
        }
       

        private void GetAuthorByIdButton_Click(object sender, EventArgs e)
        {
            bool isAuthorIdTextBoxIsNullOrWhiteSpace = CheckTextBoxIsNullOrWhiteSpace(AuthorIdTextBox, ErrorsTypes.AuthorIdMustBeProvided);

            if (isAuthorIdTextBoxIsNullOrWhiteSpace)
            {
                return;
            }

            _getAllAuthors = _authorsApiClient.GetAuthors();

            if (_getAllAuthors.Count == 0)
            {
                _messageDialogService.ShowErrorMessage(ErrorsTypes.ThereIsNoAuthors);
                ClearAllAuthorsTextBoxes();
                return;
            }

            int maxId = _getAllAuthors.Max(a => a.Id);
           
            int id = int.Parse(AuthorIdTextBox.Text);

            if (maxId < id || id == 0)
            {
                _messageDialogService.ShowErrorMessage(ErrorsTypes.BadAuthorId);
                ClearAllAuthorsTextBoxes();
                return;
            }

            var getAuthor = _authorsApiClient.GetAuthor(id);

            if (getAuthor != null)
            {
                AuthorFirstNameTextBox.Text = getAuthor.FirstName;
                AuthorLastNameTextBox.Text = getAuthor.LastName;
            }
            else
            {
                _messageDialogService.ShowErrorMessage(ErrorsTypes.BadAuthorId);
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
                CheckTextBoxIsNullOrWhiteSpace(AuthorFirstNameTextBox, ErrorsTypes.AuthorFirstNameMustBeProvided);
            bool isAuthorLastNameTextBoxIsNullOrWhiteSpace =
                CheckTextBoxIsNullOrWhiteSpace(AuthorLastNameTextBox, ErrorsTypes.AuthorLastNameMustBeProvided);

            if (isAuthorFirstNameTextBoxIsNullOrWhiteSpace || isAuthorLastNameTextBoxIsNullOrWhiteSpace)
            {
                return;
            }

            AuthorModel newAuthor = GetAuthorInfoFromTextBoxes();

            bool isCreated = _authorsApiClient.CreateNewAuthor(newAuthor);

            ShowStatusMessage(isCreated, "New Author Created successfully", ErrorsTypes.NewAuthorWasNotCreated);
        }

        private void UpdateAuthorButton_Click(object sender, EventArgs e)
        {
            bool isAuthorIdTextBoxIsNullOrWhiteSpace = CheckTextBoxIsNullOrWhiteSpace(AuthorIdTextBox, ErrorsTypes.AuthorIdMustBeProvided);
            bool isAuthorFirstNameTextBoxIsNullOrWhiteSpace =
                CheckTextBoxIsNullOrWhiteSpace(AuthorFirstNameTextBox, ErrorsTypes.AuthorFirstNameMustBeProvided);
            bool isAuthorLastNameTextBoxIsNullOrWhiteSpace =
                CheckTextBoxIsNullOrWhiteSpace(AuthorLastNameTextBox, ErrorsTypes.AuthorLastNameMustBeProvided);

            if (isAuthorIdTextBoxIsNullOrWhiteSpace || isAuthorFirstNameTextBoxIsNullOrWhiteSpace || isAuthorLastNameTextBoxIsNullOrWhiteSpace)
            {
                return;
            }

            _getAllAuthors = _authorsApiClient.GetAuthors();

            if (_getAllAuthors.Count == 0)
            {
                _messageDialogService.ShowErrorMessage(ErrorsTypes.ThereIsNoAuthors);
                return;
            }

            int maxId = _getAllAuthors.Max(a => a.Id);

            int id = int.Parse(AuthorIdTextBox.Text);

            if (maxId < id || id == 0)
            {
                _messageDialogService.ShowErrorMessage(ErrorsTypes.BadAuthorId);
                ClearAllAuthorsTextBoxes();
                return;
            }

            AuthorModel updateAuthor = GetAuthorInfoFromTextBoxes();

            bool isUpdated = _authorsApiClient.UpdateAuthorById(updateAuthor, id);

            ShowStatusMessage(isUpdated, "Updated Successful", ErrorsTypes.AuthorWasNotUpdated);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            bool isAuthorIdTextBoxIsNullOrWhiteSpace = CheckTextBoxIsNullOrWhiteSpace(AuthorIdTextBox, ErrorsTypes.AuthorIdMustBeProvided);

            if (isAuthorIdTextBoxIsNullOrWhiteSpace)
            {
                return;
            }

            int id = int.Parse(AuthorIdTextBox.Text);

            bool isDeleted = _authorsApiClient.DeleteAuthorById(id);

            ShowStatusMessage(isDeleted, "Deleted Successful", ErrorsTypes.AuthorWasDeletedBeforeOrNotExitsAtAll);
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
                CheckTextBoxIsNullOrWhiteSpace(BookIdTextBox, ErrorsTypes.BookIdMustBeProvided);

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
                _messageDialogService.ShowErrorMessage(ErrorsTypes.BookNotFound);
            }
        }

        private void CreateNewBookButton_Click(object sender, EventArgs e)
        {
            bool isBookAuthorIdTextBoxIsNullOrWhiteSpace =
                CheckTextBoxIsNullOrWhiteSpace(BookAuthorIdTextBox, ErrorsTypes.AuthorIdMustBeProvided);
            bool isBookNameTextBoxIsNullOrWhiteSpace =
                CheckTextBoxIsNullOrWhiteSpace(BookNameTextBox, ErrorsTypes.BookNameMustBeProvided);
            bool isReleaseYearTextBoxIsNullOrWhiteSpace =
                CheckTextBoxIsNullOrWhiteSpace(ReleaseYearTextBox, ErrorsTypes.YearMustBeProvided);

            if (isBookAuthorIdTextBoxIsNullOrWhiteSpace || isBookNameTextBoxIsNullOrWhiteSpace || isReleaseYearTextBoxIsNullOrWhiteSpace)
            {
                return;
            }
            
            BookModel newBook = GetBookInfoFromTextBoxes();

            bool isCreated = _booksApiClient.CreateNewAuthor(newBook);

            ShowStatusMessage(isCreated, "New Book Created successfully", ErrorsTypes.NewBookWasNotCreated);
        }

        private void UpdateBookButton_Click(object sender, EventArgs e)
        {
            bool isBookIdTextBoxIsNullOrWhiteSpace =
                CheckTextBoxIsNullOrWhiteSpace(BookIdTextBox, ErrorsTypes.BookIdMustBeProvided);
            bool isBookAuthorIdTextBoxIsNullOrWhiteSpace =
                CheckTextBoxIsNullOrWhiteSpace(BookAuthorIdTextBox, ErrorsTypes.AuthorIdMustBeProvided);
            bool isBookNameTextBoxIsNullOrWhiteSpace =
                CheckTextBoxIsNullOrWhiteSpace(BookNameTextBox, ErrorsTypes.BookNameMustBeProvided);
            bool isReleaseYearTextBoxIsNullOrWhiteSpace =
                CheckTextBoxIsNullOrWhiteSpace(ReleaseYearTextBox, ErrorsTypes.YearMustBeProvided);

            if (isBookIdTextBoxIsNullOrWhiteSpace || isBookAuthorIdTextBoxIsNullOrWhiteSpace || isBookNameTextBoxIsNullOrWhiteSpace || isReleaseYearTextBoxIsNullOrWhiteSpace)
            {
                return;
            }

            int id = int.Parse(BookIdTextBox.Text);

            BookModel updateBook = GetBookInfoFromTextBoxes();

            bool isBookUpdated = _booksApiClient.UpdateBookById(updateBook, id);

            ShowStatusMessage(isBookUpdated, "Book updated Successfully", ErrorsTypes.BookWasNotUpdated);
        }

        private void DeleteBookButton_Click(object sender, EventArgs e)
        {
            bool isBookIdTextBoxIsNullOrWhiteSpace = CheckTextBoxIsNullOrWhiteSpace(BookIdTextBox, ErrorsTypes.BookIdMustBeProvided);

            if (isBookIdTextBoxIsNullOrWhiteSpace)
            {
                return;
            }

            int id = int.Parse(BookIdTextBox.Text);

            bool isDeleted = _booksApiClient.DeleteBookById(id);

            ShowStatusMessage(isDeleted, "Deleted Successful", ErrorsTypes.BookWasDeletedBeforeOrNotExitsAtAll);
        }

        private void ClearAllAuthorsTextBoxesButton_Click(object sender, EventArgs e)
        {
            ClearAllAuthorsTextBoxes();
        }

        private void ClearAllBooksTextBoxesButton_Click(object sender, EventArgs e)
        {
            ClearAllBooksTextBoxes();
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

        private void ClearAllAuthorsTextBoxes()
        {
            AuthorIdTextBox.Clear();
            AuthorFirstNameTextBox.Clear();
            AuthorLastNameTextBox.Clear();
        }

        private void ClearAllBooksTextBoxes()
        {
            BookIdTextBox.Clear();
            BookAuthorIdTextBox.Clear();
            BookNameTextBox.Clear();
            ReleaseYearTextBox.Clear();
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

        private void ShowStatusMessage(bool isSuccessful, string successMessage, ErrorsTypes errorsTypes)
        {
            if (isSuccessful)
            {
                _messageDialogService.ShowInfoMessage(successMessage);
            }
            else
            {
                _messageDialogService.ShowErrorMessage(errorsTypes);
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
            const int releaseYearLength = 4;

            AuthorFirstNameTextBox.MaxLength = TextBoxMaxLength;
            AuthorLastNameTextBox.MaxLength = TextBoxMaxLength;

            BookNameTextBox.MaxLength = TextBoxMaxLength;
            ReleaseYearTextBox.MaxLength = releaseYearLength;
        }

        private void ForceTextBoxToBeNumber(TextBox textBox)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, "[^0-9]"))
            {
                _messageDialogService.ShowErrorMessage(ErrorsTypes.TextMustBeInteger);
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private bool CheckTextBoxIsNullOrWhiteSpace(TextBox textBox, ErrorsTypes errorsTypes)
        {
            bool isNullOrWhiteSpace = false;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                _messageDialogService.ShowErrorMessage(errorsTypes);
                textBox.BackColor = Color.Red;
                isNullOrWhiteSpace = true;
            }

            return isNullOrWhiteSpace;
        }

        #endregion
        
    }
}
