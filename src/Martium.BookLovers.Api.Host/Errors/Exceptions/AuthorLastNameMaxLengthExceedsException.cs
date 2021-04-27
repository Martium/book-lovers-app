namespace Martium.BookLovers.Api.Host.Errors.Exceptions
{
    public class AuthorLastNameMaxLengthExceedsException : BadRequestException
    {
        public AuthorLastNameMaxLengthExceedsException() : base("MaxLengthExceeds", "The size of the Author Last Name exceeds the maximum size permitted.")
        {
            
        }
    }
}
