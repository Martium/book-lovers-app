using System.Windows.Forms;
using Martium.BookLovers.Web.Enums;

namespace Martium.BookLovers.Web.Service
{
    public class MessageDialogService
    {
        private readonly ErrorMessage _errorMessage;
        private readonly InfoMessage _infoMessage;

        public MessageDialogService()
        {
            _errorMessage = new ErrorMessage();
            _infoMessage = new InfoMessage();
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

        public void ShowInfoMessage(InfoTypes infoTypes)
        {
            switch (infoTypes)
            {
                case InfoTypes.NewAuthorCreated:
                    MessageBox.Show(_infoMessage.NewAuthorCreated);
                    break;
                case InfoTypes.AuthorUpdateSuccessful:
                    MessageBox.Show(_infoMessage.AuthorUpdateSuccessful);
                    break;
                case InfoTypes.AuthorDeletedSuccessful:
                    MessageBox.Show(_infoMessage.AuthorDeletedSuccessful);
                    break;
                case InfoTypes.NewBookCreated:
                    MessageBox.Show(_infoMessage.NewBookCreated);
                    break;
                case InfoTypes.BookUpdatedSuccessfully:
                    MessageBox.Show(_infoMessage.BookUpdatedSuccessfully);
                    break;
                case InfoTypes.BookDeletedSuccessfully:
                    MessageBox.Show(_infoMessage.BookDeletedSuccessfully);
                    break;
            }
        }


    }
}
