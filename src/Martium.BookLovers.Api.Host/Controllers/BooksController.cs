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
                List<BookReadModel> authorsBooks = _books.GetAllAuthorsBooks(authorId.Value)
                    .FindAll(a => a.AuthorId == authorId.Value);

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
            BookReadModel book = _books.GetBookById(id);

            if (book == null)
            {
                return NotFound("bookNotFound");
            }
            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("books")]
        public ActionResult<AuthorReadModel> Create([FromBody] BookModel bookRequest)
        {
            BookReadModel bookByAuthorId = _books.CheckBookByAuthorId(bookRequest.AuthorId);

            if (bookByAuthorId == null)
            {
                return NotFound("authorNotFound");
            }

            int id = _books.CreateNewBook(bookRequest);

            BookReadModel newBook = _books.GetBookById(id); // nesugalvoju kaip viena karta saukt repositorija

            return CreatedAtAction(nameof(GetById), new { id }, newBook);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("books/{id}")]
        public ActionResult<AuthorReadModel> Update(int id, [FromBody] BookModel updateBook)
        {
            BookReadModel bookByAuthorId = _books.CheckBookByAuthorId(updateBook.AuthorId);

            if (bookByAuthorId == null)
            {
                return NotFound("authorNotFound");
            }

            BookReadModel bookById = _books.GetBookById(id); // nesugalvoju kaip viena karta saukt repositorija

            if (bookById == null)
            {
                return NotFound("bookNotFound");
            }

            _books.UpdateBookById(id, updateBook);
            
            return Ok(bookById);
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
