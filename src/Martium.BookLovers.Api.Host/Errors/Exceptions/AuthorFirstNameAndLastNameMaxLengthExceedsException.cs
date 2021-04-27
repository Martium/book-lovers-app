namespace Martium.BookLovers.Api.Host.Errors.Exceptions
{
    public class AuthorFirstNameAndLastNameMaxLengthExceedsException : BadRequestException
    {
        public AuthorFirstNameAndLastNameMaxLengthExceedsException(): base("MaxLengthExceeds", "The size of the Author First Name and Last name exceeds the maximum size permitted.")
        {
        }
    }
}
