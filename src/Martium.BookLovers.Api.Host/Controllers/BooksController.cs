using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Martium.BookLovers.Api.Contracts.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Martium.BookLovers.Api.Host.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("v1/bookLovers")]
    public class BooksController : ControllerBase
    {

        private static List<AuthorReadModel> _authors = new List<AuthorReadModel>
        {
            new AuthorReadModel { Id = 1, FirstName = "Joanne", LastName =  "Rowling" },
            new AuthorReadModel { Id = 2, FirstName = "George", LastName = "Raymond Richard Martin" }
        };

        private static List<BookReadModel> _books = new List<BookReadModel>()
        {
            new BookReadModel { AuthorId = _authors[0].Id, Id = 1, BookName = "Harry Potter and the Philosopher's Stone", ReleaseYear = new DateTime(1997,06, 26) },
            new BookReadModel { AuthorId = _authors[0].Id, Id = 2, BookName = "Harry Potter and the Chamber of Secrets", ReleaseYear =  new DateTime(1998, 07, 2) },
            new BookReadModel { AuthorId = _authors[0].Id, Id = 3, BookName = "Harry Potter and the Prisoner of Azkaban", ReleaseYear = new DateTime(1999, 07, 8) },

            new BookReadModel { AuthorId = _authors[1].Id, Id = 1, BookName = "A Game of Thrones", ReleaseYear = new DateTime(1996,08,1) },
            new BookReadModel { AuthorId = _authors[1].Id, Id = 2, BookName = "A Clash of Kings", ReleaseYear = new DateTime(1998,11,6) },
            new BookReadModel { AuthorId = _authors[1].Id, Id = 3, BookName = "A Storm of Swords", ReleaseYear = new DateTime(2000,08,8) }
        };

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("books/{authorsId}")]
        public ActionResult<IEnumerable<AuthorReadModel>> GetAllAuthorBooks(int authorsId)
        {
            AuthorReadModel author = _authors.FirstOrDefault(x => x.Id == authorsId);

            if (author == null)
            {
                return NotFound("author not found");
            }

            var authorBooks = _books.FindAll(c => c.AuthorId == authorsId);

            return Ok(authorBooks);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("books/{authorsId}/{bookId}")]
        public ActionResult<IEnumerable<AuthorReadModel>> GetAuthorBook(int authorsId, int bookId)
        {
            AuthorReadModel author = _authors.FirstOrDefault(x => x.Id == authorsId);
            BookReadModel authorBook = _books.FirstOrDefault(y => y.Id == bookId);

            if (author == null)
            {
                return NotFound("author not found");
            }

            if (authorBook == null)
            {
                return NotFound("author book not found");
            }

            return Ok(authorBook);
        }
    }
}
