using System.Collections.Generic;
using System.Linq;
using Martium.BookLovers.Api.Contracts.Request;
using Martium.BookLovers.Api.Contracts.Response;
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("authors")]
        public ActionResult<IEnumerable<AuthorReadModel>> GetList()
        {
            return Ok(Authors);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("authors/{id}")]
        public ActionResult<AuthorReadModel> GetById(int id)
        {
            AuthorReadModel author = Authors.FirstOrDefault(a => a.Id == id);

            if (author == null)
            {
                return NotFound("authorNotFound");
            }

            return Ok(author);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("authors")]
        public ActionResult<AuthorReadModel> Create([FromBody] AuthorModel authorRequest)
        {
            int newId = Authors.Max(a => a.Id) + 1;

            var newAuthor = new AuthorReadModel()
            {
                Id = newId, 
                FirstName = authorRequest.FirstName, 
                LastName = authorRequest.LastName
            };

            Authors.Add(newAuthor);

            return CreatedAtAction(nameof(GetById), new { id = newId }, newAuthor);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("authors/{id}")]
        public ActionResult<AuthorReadModel> Update([FromBody] AuthorModel authorUpdate, int id)
        {
            AuthorReadModel author = Authors.SingleOrDefault(a => a.Id == id);

            if (author == null)
            {
                return NotFound("authorNotFound");
            }

            author.FirstName = authorUpdate.FirstName;
            author.LastName = authorUpdate.LastName;

            return Ok(author);
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
