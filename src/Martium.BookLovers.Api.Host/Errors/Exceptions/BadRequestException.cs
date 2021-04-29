using System.Net;

namespace Martium.BookLovers.Api.Host.Errors.Exceptions
{
    public class BadRequestException : ApiException
    {
        public BadRequestException(string reason, string message) 
            : base(HttpStatusCode.BadRequest, reason, message)
        {
        }
    }
}
