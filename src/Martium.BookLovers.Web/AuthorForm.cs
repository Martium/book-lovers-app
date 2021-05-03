using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Martium.BookLovers.Api.Client;
using Martium.BookLovers.Api.Contracts.Response;

namespace Martium.BookLovers.Web
{
    public partial class AuthorForm : Form
    {
        private readonly AuthorsApiClient _authorsApiClient;

        private  List<AuthorReadModel> _getAllAuthors;

        public AuthorForm()
        {
            InitializeComponent();

            _authorsApiClient = new AuthorsApiClient();

            _getAllAuthors = new List<AuthorReadModel>();

            MakeComboBoxReadOnly();
        }

        private void GetAllAuthorsButton_Click(object sender, System.EventArgs e)
        {
            ClearComboBox();

             _getAllAuthors = _authorsApiClient.GetAuthors();

            if (_getAllAuthors != null)
            {
                foreach (var allAuthor in _getAllAuthors)
                {
                    AuthorIdComboBox.Items.Add(allAuthor.Id.ToString());
                    AuthorFirstNameComboBox.Items.Add(allAuthor.FirstName);
                    AuthorLastNameComboBox.Items.Add(allAuthor.LastName);
                }

                DisplayFirstElementInComboBoxes(_getAllAuthors);
            }
        }

        private void MakeComboBoxReadOnly()
        {
            AuthorIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            AuthorFirstNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            AuthorLastNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ClearComboBox()
        {
            AuthorIdComboBox.Items.Clear();
            AuthorFirstNameComboBox.Items.Clear();
            AuthorLastNameComboBox.Items.Clear();
        }

        private void DisplayFirstElementInComboBoxes(List<AuthorReadModel> getAllAuthors)
        {
            int id = getAllAuthors.First().Id;

            AuthorIdComboBox.Text = id.ToString();
            AuthorFirstNameComboBox.Text = getAllAuthors.Find(a => a.Id == id).FirstName;
            AuthorLastNameComboBox.Text = getAllAuthors.Find(a => a.Id == id).LastName;
        }

        private void AuthorIdComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int id = int.Parse(AuthorIdComboBox.Text);
            AuthorFirstNameComboBox.Text = _getAllAuthors.Find(a => a.Id == id).FirstName;
            AuthorLastNameComboBox.Text = _getAllAuthors.Find(a => a.Id == id).LastName;
        }
    }
}
