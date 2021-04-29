namespace Martium.BookLovers.Api.Host.Errors.Exceptions
{
    public class BookYearsInvalidException : BadRequestException
    {
        public BookYearsInvalidException() : base("bookYearsInvalid", "Book years can not be negative number or zero")
        {
            
        }
    }
}
