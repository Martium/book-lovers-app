namespace Martium.BookLovers.Api.Host.Errors.Exceptions
{
    public class AuthorBadRequestException : BadRequestException
    {
        public AuthorBadRequestException() : base("invalidAuthorIdProvided", "Invalid Author Id was provided.")
        {
            
        }
    }
}
