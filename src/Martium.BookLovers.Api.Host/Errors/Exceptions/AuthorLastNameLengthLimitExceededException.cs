using Martium.BookLovers.Api.Host.Constants;

namespace Martium.BookLovers.Api.Host.Errors.Exceptions
{
    public class AuthorLastNameLengthLimitExceededException : BadRequestException
    {
        public AuthorLastNameLengthLimitExceededException() : base("authorLastNameLengthLimitExceeded", $"The maximum length of author last name cannot exceed '{BookLoversSettings.AuthorLengths.LastName}' characters")
        {
            
        }
    }
}
