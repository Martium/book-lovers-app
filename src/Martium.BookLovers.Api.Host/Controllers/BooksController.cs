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
        private readonly AuthorRepository _authorRepository = new AuthorRepository();

        private readonly BookRepository _bookRepository = new BookRepository();

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("books")]
        public ActionResult<List<AuthorReadModel>> GetList([FromQuery] int? authorId)
        {
            List<BookReadModel> books = new List<BookReadModel>();

            books = authorId.HasValue 
                ? _bookRepository.GetAllAuthorsBooks(authorId.Value) 
                : _bookRepository.GetAllBooks();

            return Ok(books);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("books/{id}")]
        public ActionResult<BookReadModel> GetById(int id)
        {
            BookReadModel book = _bookRepository.GetBookById(id);

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
            AuthorReadModel authorById = _authorRepository.GetAuthorById(bookRequest.AuthorId);

            if (authorById == null)
            {
                return BadRequest("authorNotFound");
            }

            int id = _bookRepository.CreateNewBook(bookRequest);

            BookReadModel newBook = _bookRepository.GetBookById(id); 

            return CreatedAtAction(nameof(GetById), new { id }, newBook);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("books/{id}")]
        public ActionResult<AuthorReadModel> Update(int id, [FromBody] BookModel updateBook)
        {
            AuthorReadModel authorById = _authorRepository.GetAuthorById(updateBook.AuthorId);

            if (authorById == null)
            {
                return BadRequest("authorNotFound");
            }

            BookReadModel bookById = _bookRepository.GetBookById(id); 

            if (bookById == null)
            {
                return NotFound("bookNotFound");
            }

            _bookRepository.UpdateBookById(id, updateBook);

            var updatedBook = _bookRepository.GetBookById(id);
            
            return Ok(updatedBook);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Route("books/{id}")]
        public ActionResult DeleteBook(int id)
        {
            BookReadModel bookById = _bookRepository.GetBookById(id);

            if (bookById == null)
            {
                return NotFound("bookNotFound");
            }

            _bookRepository.DeleteBookById(id);

            return NoContent();
        }
    }
}
