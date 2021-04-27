namespace Martium.BookLovers.Api.Host.Errors.Exceptions
{
    public class AuthorFirstNameMaxLengthExceedsException : BadRequestException
    {
        public AuthorFirstNameMaxLengthExceedsException() : base("MaxLengthExceeds", "The size of the Author First Name exceeds the maximum size permitted.")
        {
            
        }
    }
}
