using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Martium.BookLovers.Api.Host.Errors.Exceptions
{
    public class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException() : base("bookNotFound", "Book was not found.")
        {
            
        }
    }
}
