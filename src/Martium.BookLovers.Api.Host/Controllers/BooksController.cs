using System.Collections.Generic;
using System.Linq;
using Martium.BookLovers.Api.Contracts.Request;
using Martium.BookLovers.Api.Contracts.Response;
using Martium.BookLovers.Api.Host.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Martium.BookLovers.Api.Host.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("v1/bookLovers")]
    public class BooksController : ControllerBase
    {
        public static List<BookReadModel> Books = new List<BookReadModel>()
        {
            new BookReadModel { AuthorId = AuthorsController.Authors[0].Id, Id = 1, BookName = "Harry Potter and the Philosopher's Stone", ReleaseYear = 1997 },
            new BookReadModel { AuthorId = AuthorsController.Authors[0].Id, Id = 2, BookName = "Harry Potter and the Chamber of Secrets", ReleaseYear =  1998 },
            new BookReadModel { AuthorId = AuthorsController.Authors[0].Id, Id = 3, BookName = "Harry Potter and the Prisoner of Azkaban", ReleaseYear = 1999 },

            new BookReadModel { AuthorId = AuthorsController.Authors[1].Id, Id = 4, BookName = "A Game of Thrones", ReleaseYear = 1996 },
            new BookReadModel { AuthorId = AuthorsController.Authors[1].Id, Id = 5, BookName = "A Clash of Kings", ReleaseYear = 1998 },
            new BookReadModel { AuthorId = AuthorsController.Authors[1].Id, Id = 6, BookName = "A Storm of Swords", ReleaseYear = 2000 }
        };

        private readonly BookRepository _books = new BookRepository();

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("books")]
        public ActionResult<IEnumerable<AuthorReadModel>> GetList([FromQuery] int? authorId)
        {
            if (authorId.HasValue)
            {
                bool isAuthorIdExists = _books.CheckAuthorId(authorId.Value);

                if (!isAuthorIdExists)
                {
                    return NotFound("authorNotFound");
                }

                List<BookReadModel> authorsBooks = _books.GetAllAuthorsBooks(authorId.Value);

                return Ok(authorsBooks);
            }

            List<BookReadModel> books = _books.GetAllBooks();
            return Ok(books);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("books/{id}")]
        public ActionResult<BookReadModel> GetById(int id)
        {
            bool isBookIdExists = _books.CheckBookId(id);

            if (!isBookIdExists)
            {
                return NotFound("bookNotFound");
            }

            BookReadModel book = _books.GetBookById(id);
            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("books")]
        public ActionResult<AuthorReadModel> Create([FromBody] BookModel book)
        {
            if (!AuthorsController.Authors.Exists(a => a.Id == book.AuthorId))
            {
                return NotFound("authorNotFound");
            }

            int newBookId = Books.Max(b => b.Id) + 1;

            var newBook = new BookReadModel
            {
                AuthorId = book.AuthorId,
                Id = newBookId,
                BookName = book.BookName,
                ReleaseYear = book.ReleaseYear
            };

            Books.Add(newBook);

            return CreatedAtAction(nameof(GetById), new { id = newBookId }, newBook);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("books/{id}")]
        public ActionResult<AuthorReadModel> Update(int id, [FromBody] BookModel updatedBook)
        {
            if (!AuthorsController.Authors.Exists(a => a.Id == updatedBook.AuthorId))
            {
                return NotFound("authorNotFound");
            }

            BookReadModel book = Books.SingleOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound("bookNotFound");
            }

            book.AuthorId = updatedBook.AuthorId;
            book.BookName = updatedBook.BookName;
            book.ReleaseYear = updatedBook.ReleaseYear;

            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Route("books/{id}")]
        public ActionResult DeleteBook(int id)
        {
            BookReadModel book = Books.SingleOrDefault(b => b.Id == id);

            if (book != null)
            {
                Books.Remove(book);
            }

            return NoContent();
        }
    }
}
