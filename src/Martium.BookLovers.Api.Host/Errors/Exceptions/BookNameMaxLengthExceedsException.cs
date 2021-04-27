namespace Martium.BookLovers.Api.Host.Errors.Exceptions
{
    public class BookNameMaxLengthExceedsException : BadRequestException
    {
        public BookNameMaxLengthExceedsException() : base("MaxLengthExceeds", "The size of the Book Name exceeds the maximum size permitted.")
        {
            
        }
    }
}
