using Martium.BookLovers.Api.Host.Constants;

namespace Martium.BookLovers.Api.Host.Errors.Exceptions
{
    public class AuthorFirstNameLengthLimitExceededException : BadRequestException
    {
        public AuthorFirstNameLengthLimitExceededException() : base("authorFirstNameLengthLimitExceeded", $"The maximum length of author first name cannot exceed '{BookLoversSettings.AuthorLengths.FirstName}' characters")
        {
            
        }
    }
}
