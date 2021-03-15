using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Martium.BookLovers.Api.Contracts.Request;
using Martium.BookLovers.Api.Contracts.Response;
using Martium.BookLovers.Api.Host.Constants;
using Martium.BookLovers.Api.Host.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Martium.BookLovers.Api.Host.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("v1/bookLovers")]
    public class AuthorsController : ControllerBase
    {
        public static List<AuthorReadModel> Authors = new List<AuthorReadModel>
        {
            new AuthorReadModel { Id = 1, FirstName = "Joanne", LastName =  "Rowling" },
            new AuthorReadModel { Id = 2, FirstName = "George", LastName = "Raymond Richard Martin" }
        };

        private readonly BookLoversRepository _authors = new BookLoversRepository();

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("authors")]
        public ActionResult<IEnumerable<AuthorReadModel>> GetList()
        {
            return Ok(_authors.GetAuthors());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("authors/{id}")]
        public ActionResult<AuthorReadModel> GetById(int id)
        {
            var getAuthor = _authors.GetAuthorById(id);

            if (getAuthor == null)
            {
                return NotFound("authorNotFound");
            }

            return Ok(getAuthor);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("authors")]
        public ActionResult<AuthorReadModel> Create([FromBody] AuthorModel authorRequest)
        {
            var newAuthor = _authors.CreateNewAuthor(authorRequest);

            return CreatedAtAction(nameof(Create), newAuthor);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("authors/{id}")]
        public ActionResult<AuthorReadModel> Update([FromBody] AuthorModel authorUpdate, int id)
        {
            bool newAuthor = _authors.UpdateAuthorById(id, authorUpdate);

            if (newAuthor == false)
            {
                return NotFound("authorNotFound");
            }

            return Ok(newAuthor);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Route("authors/{id}")]
        public ActionResult Delete(int id)
        {
            AuthorReadModel author = Authors.SingleOrDefault(a => a.Id == id);

            if (author != null)
            {
                BooksController.Books.RemoveAll(c => c.AuthorId == id);
                Authors.Remove(author);
            }

            return NoContent();
        }
    }
}
