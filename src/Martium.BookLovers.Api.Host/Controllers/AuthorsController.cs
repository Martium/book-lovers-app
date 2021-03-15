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
            bool isAuthorCreated = _authors.CreateNewAuthor(authorRequest);

            return CreatedAtAction(nameof(Create), isAuthorCreated);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("authors/{id}")]
        public ActionResult<AuthorReadModel> Update([FromBody] AuthorModel authorUpdate, int id)
        {
            bool isAuthorUpdatable = _authors.UpdateAuthorById(id, authorUpdate);

            if (isAuthorUpdatable == false)
            {
                return NotFound("authorNotFound");
            }

            return Ok(isAuthorUpdatable);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Route("authors/{id}")]
        public ActionResult Delete(int id)
        {
            bool isAuthorDeletable = _authors.DeleteAuthorById(id);

            if (isAuthorDeletable == false)
            {
                return NotFound("authorNotFound");
            }

            return NoContent();
        }
    }
}
