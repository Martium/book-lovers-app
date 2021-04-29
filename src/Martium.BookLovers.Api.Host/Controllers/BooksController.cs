using System.Collections.Generic;
using Martium.BookLovers.Api.Contracts.Request;
using Martium.BookLovers.Api.Contracts.Response;
using Martium.BookLovers.Api.Host.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Martium.BookLovers.Api.Host.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("v1/bookLovers")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService = new BookService();

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("books")]
        public ActionResult<List<AuthorReadModel>> GetList([FromQuery] int? authorId)
        {
            List<BookReadModel> books = _bookService.GetList(authorId);

            return Ok(books);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("books/{id}")]
        public ActionResult<BookReadModel> GetById(int id)
        {
            BookReadModel book = _bookService.GetBookById(id);
           
            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("books")]
        public ActionResult<AuthorReadModel> Create([FromBody] BookModel bookRequest)
        {
            BookReadModel newBook = _bookService.CreateNewBook(bookRequest);

            return CreatedAtAction(nameof(GetById), new { newBook.Id }, newBook);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("books/{id}")]
        public ActionResult<AuthorReadModel> Update(int id, [FromBody] BookModel updateBook)
        {
            BookReadModel updatedBook = _bookService.UpdateNewBook(updateBook, id);
            
            return Ok(updatedBook);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Route("books/{id}")]
        public ActionResult DeleteBook(int id)
        {
           _bookService.DeleteBookById(id);

            return NoContent();
        }
    }
}
