namespace Martium.BookLovers.Api.Host.Errors.Exceptions
{
    public class AuthorNotFoundException : NotFoundException
    {
        public AuthorNotFoundException() : base("authorNotFound", "Author was not found.")
        {
            
        }
    }
}
