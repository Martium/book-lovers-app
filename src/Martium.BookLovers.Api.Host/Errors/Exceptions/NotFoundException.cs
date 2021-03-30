using System.Net;

namespace Martium.BookLovers.Api.Host.Errors
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(string reason, string message)
            : base(HttpStatusCode.NotFound, reason, message)
        {
        }
    }
}