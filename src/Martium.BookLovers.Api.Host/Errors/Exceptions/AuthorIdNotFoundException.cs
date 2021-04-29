namespace Martium.BookLovers.Api.Host.Errors.Exceptions
{
    public class AuthorIdNotFoundException : BadRequestException
    {
        public AuthorIdNotFoundException() : base("notFoundAuthorIdProvided", "Author with provided 'authorId' was not found")
        {
            
        }
    }
}
