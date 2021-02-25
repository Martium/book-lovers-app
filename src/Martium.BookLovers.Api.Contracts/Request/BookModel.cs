using System;
using System.Collections.Generic;
using System.Text;

namespace Martium.BookLovers.Api.Contracts.Request
{
    public class BookModel
    {
        public string BookName { get; set; }
        public int ReleaseYear { get; set; }
    }
}
