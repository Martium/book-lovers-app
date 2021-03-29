using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Martium.BookLovers.Api.Host.Constants
{
    public class BookLoversSettings
    {
        public class AuthorLengths
        {
            public static int FirstName => 100;
            public static int LastName => 100;
        }

        public class BookLengths
        {
            public static int BookName => 100;
        }
    }
}
