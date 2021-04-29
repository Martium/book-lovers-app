using System.Net;

namespace Martium.BookLovers.Api.Host.Errors.Exceptions
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(string reason, string message)
            : base(HttpStatusCode.NotFound, reason, message)
        {
        }
    }
}