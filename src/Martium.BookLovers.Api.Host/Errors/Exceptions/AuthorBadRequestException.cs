using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Martium.BookLovers.Api.Host.Errors.Exceptions
{
    public class AuthorBadRequestException : BadRequestException
    {
        public AuthorBadRequestException() : base("invalidAuthorIdProvided", "Invalid Author Id was provided.")
        {
            
        }
    }
}
