namespace Martium.BookLovers.Api.Host.Errors.Exceptions
{
    public class BookYearsCannotBeInFutureException : BadRequestException
    {
        public BookYearsCannotBeInFutureException() : base("BookYearsCannotBeInFuture", "You cannot create book which will be released in the future")
        {
            
        }
    }
}
