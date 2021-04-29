using System;
using System.Net;

namespace Martium.BookLovers.Api.Host.Errors.Exceptions
{
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public String Reason { get; set; }

        public ApiException(HttpStatusCode statusCode, string reason, string message) : base(message)
        {
            StatusCode = statusCode;
            Reason = reason;
        }
    }
}
