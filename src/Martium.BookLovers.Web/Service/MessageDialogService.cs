using System.Windows.Forms;
using Martium.BookLovers.Web.Enums;

namespace Martium.BookLovers.Web.Service
{
    public class MessageDialogService
    {
        private readonly ErrorMessage _errorMessage;

        public MessageDialogService()
        {
            _errorMessage = new ErrorMessage();
        }

        public void ShowErrorMessage(ErrorsTypes errorsTypes)
        {
            switch (errorsTypes)
            {
                case ErrorsTypes.AuthorIdMustBeProvided:
                    MessageBox.Show(_errorMessage.AuthorIdMustBeProvided);
                    break;
                case ErrorsTypes.BookIdMustBeProvided:
                    MessageBox.Show(_errorMessage.BookIdMustBeProvided);
                    break;
                case ErrorsTypes.BadAuthorId:
                    MessageBox.Show(_errorMessage.BadAuthorId);
                    break;
                case ErrorsTypes.ThereIsNoAuthors:
                    MessageBox.Show(_errorMessage.ThereIsNoAuthors);
                    break;
                case ErrorsTypes.TextMustBeInteger:
                    MessageBox.Show(_errorMessage.TextMustBeInteger);
                    break;
                case ErrorsTypes.AuthorFirstNameMustBeProvided:
                    MessageBox.Show(_errorMessage.AuthorFirstNameMustBeProvided);
                    break;
                case ErrorsTypes.AuthorLastNameMustBeProvided:
                    MessageBox.Show(_errorMessage.AuthorLastNameMustBeProvided);
                    break;
                case ErrorsTypes.BookNotFound:
                    MessageBox.Show(_errorMessage.BookNotFound);
                    break;
                case ErrorsTypes.BookNameMustBeProvided:
                    MessageBox.Show(_errorMessage.BookNameMustBeProvided);
                    break;
                case ErrorsTypes.YearMustBeProvided:
                    MessageBox.Show(_errorMessage.YearMustBeProvided);
                    break;
                case ErrorsTypes.AuthorWasNotUpdated:
                    MessageBox.Show(_errorMessage.AuthorWasNotUpdated);
                    break;
                case ErrorsTypes.AuthorWasDeletedBeforeOrNotExitsAtAll:
                    MessageBox.Show(_errorMessage.AuthorWasDeletedBeforeOrNotExitsAtAll);
                    break;
                case ErrorsTypes.NewBookWasNotCreated:
                    MessageBox.Show(_errorMessage.NewBookWasNotCreated);
                    break;
                case ErrorsTypes.BookWasNotUpdated:
                    MessageBox.Show(_errorMessage.BookWasNotUpdated);
                    break;
                case ErrorsTypes.NewAuthorWasNotCreated:
                    MessageBox.Show(_errorMessage.NewAuthorWasNotCreated);
                    break;
                case ErrorsTypes.BookWasDeletedBeforeOrNotExitsAtAll:
                    MessageBox.Show(_errorMessage.BookWasDeletedBeforeOrNotExitsAtAll);
                    break;
            }
        }

        public void ShowInfoMessage(string infoMessage)
        {
            MessageBox.Show(infoMessage);
        }


    }
}
