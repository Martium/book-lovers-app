using System.Windows.Forms;

namespace Martium.BookLovers.Web.Service
{
    public class MessageDialogService
    {
        public void ShowErrorMessage(string errorMessage)
        {
            MessageBox.Show(errorMessage);
        }
    }
}
