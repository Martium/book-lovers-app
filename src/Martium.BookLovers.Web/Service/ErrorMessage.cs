namespace Martium.BookLovers.Web.Service
{
    public class ErrorMessage
    {
       public string AuthorIdMustBeProvided = "Author id must be provided";

       public string BookIdMustBeProvided = "Book id must be provided";

       public string BadAuthorId = "Author id cant be found";

       public string ThereIsNoAuthors = "There is no Authors in DataBase";

       public string TextMustBeInteger = "text must be number (integer type)";

       public string AuthorFirstNameMustBeProvided = "Author First name must be provided";

       public string AuthorLastNameMustBeProvided = "Author Last name must be provided";

       public string BookNotFound = "Book not found";

       public string BookNameMustBeProvided = "Book name must be provided";

       public string YearMustBeProvided = "Year must be provided";

       public string AuthorWasNotUpdated = "Author was not updated";

       public string AuthorWasDeletedBeforeOrNotExitsAtAll = "Cant find Author( was deleted before or not exits at all)";

       public string NewBookWasNotCreated = "New Book was not created";

       public string BookWasNotUpdated = "Book was not updated";

       public string NewAuthorWasNotCreated = "New Author was not Created";

       public string BookWasDeletedBeforeOrNotExitsAtAll = "Cant find Book( was deleted before or not exits at all)";
    }
}
