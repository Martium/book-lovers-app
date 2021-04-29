using Martium.BookLovers.Api.Host.Constants;

namespace Martium.BookLovers.Api.Host.Errors.Exceptions
{
    public class BookNameLengthLimitExceededException : BadRequestException
    {
        public BookNameLengthLimitExceededException() : base("bookNameLengthLimitExceeded", $"The maximum length of book name cannot exceed '{BookLoversSettings.BookLengths.BookName}' characters")
        {
            
        }
    }
}
