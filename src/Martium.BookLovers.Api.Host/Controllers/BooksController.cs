using System.Collections.Generic;
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
        private readonly BookRepository _books = new BookRepository();

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("books")]
        public ActionResult<AuthorReadModel> GetList([FromQuery] int? authorId)
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
        public ActionResult<AuthorReadModel> Create([FromBody] BookModel bookRequest)
        {
            bool isAuthorIdExists = _books.CheckAuthorId(bookRequest.AuthorId);

            if (!isAuthorIdExists)
            {
                return NotFound("authorNotFound");
            }

            int id = _books.CreateNewBook(bookRequest);

            BookReadModel newBook = _books.GetBookById(id);

            return CreatedAtAction(nameof(GetById), new { id }, newBook);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("books/{id}")]
        public ActionResult<AuthorReadModel> Update(int id, [FromBody] BookModel updateBook)
        {
            bool isAuthorIdExists = _books.CheckAuthorId(updateBook.AuthorId);

            if (!isAuthorIdExists)
            {
                return NotFound("authorNotFound");
            }

            bool isBookIdExists = _books.CheckBookId(id);

            if (!isBookIdExists)
            {
                return NotFound("bookNotFound");
            }

            _books.UpdateBookById(id, updateBook);

            BookReadModel updatedBook = _books.GetBookById(id);
            return Ok(updatedBook);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Route("books/{id}")]
        public ActionResult DeleteBook(int id)
        {
            _books.DeleteBookById(id);

            return NoContent();
        }
    }
}
