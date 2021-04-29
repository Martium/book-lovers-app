using System.Collections.Generic;
using System.Windows.Forms;
using Martium.BookLovers.Api.Client;
using Martium.BookLovers.Api.Contracts.Response;

namespace Martium.BookLovers.Web
{
    public partial class AuthorForm : Form
    {
        private readonly AuthorsApiClient _authorsApiClient;

        public AuthorForm()
        {
            InitializeComponent();

            _authorsApiClient = new AuthorsApiClient();

            MakeComboBoxReadOnly();
        }

        private void GetAllAuthorsButton_Click(object sender, System.EventArgs e)
        {
            List<AuthorReadModel> getAllAuthors = _authorsApiClient.GetAuthors();

            if (getAllAuthors != null)
            {
                foreach (var authors in getAllAuthors)
                {
                    FillComboBoxInfo(authors, AuthorIdComboBox, "Id");
                    FillComboBoxInfo(authors, AuthorFirstNameComboBox, "FirstName");
                    FillComboBoxInfo(authors, AuthorLastNameComboBox, "LastName");
                }
            }
        }

        private void MakeComboBoxReadOnly()
        {
            AuthorIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            AuthorFirstNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            AuthorLastNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void FillComboBoxInfo(AuthorReadModel authors, ComboBox comboBox, string readModelProp)
        {
            comboBox.DataSource = authors;
            comboBox.DisplayMember = readModelProp;
        }
    }
}
