using System.Collections.Generic;
using System.Linq;
using Martium.BookLovers.Api.Contracts.Request;
using Martium.BookLovers.Api.Contracts.Response;
using Microsoft.AspNetCore.Mvc;

namespace Martium.BookLovers.Api.Host.Controllers
{
    [ApiController]
    [Route("v1/bookLovers")]

    public class AuthorsController : ControllerBase
    {
        private static List<AuthorReadModel> _authors = new List<AuthorReadModel>
        {
            new AuthorReadModel { Id = 1, FirstName = "Joanne", LastName =  "Rowling" },
            new AuthorReadModel { Id = 2, FirstName = "George", LastName = "Raymond Richard Martin" }
        };

        [HttpGet]
        [Route("authors")]
        public ActionResult<IEnumerable<AuthorReadModel>> GetAuthors()
        {
            return Ok(_authors);
        }

        [HttpGet]
        [Route("authors/{id}")]
        public ActionResult<AuthorReadModel> GetAuthor(int id)
        {
            AuthorReadModel author = _authors.FirstOrDefault(x => x.Id == id);

            if (author != null)
            {
                return Ok(author);
            }
            else
            {
                return NotFound("NotFound");
            }
        }

        [HttpPost]
        [Route("authors")]
        public ActionResult Create([FromBody] AuthorModel authorRequest)
        {
            int newId = _authors.Max(x => x.Id) + 1;

            var newAuthor = new AuthorReadModel()
            {
                Id = newId, 
                FirstName = authorRequest.FirstName, 
                LastName = authorRequest.LastName
            };

            _authors.Add(newAuthor);

            return CreatedAtAction(nameof(GetAuthor), new { id = newId }, newAuthor);
        }

        [HttpPut]
        [Route("authors/{id}")]
        public ActionResult Update([FromBody] AuthorModel updateAuthor, int id)
        {
            var existingAuthor = _authors.FirstOrDefault(c => c.Id == id);

            if (existingAuthor != null)
            {
                existingAuthor.FirstName = updateAuthor.FirstName;
                existingAuthor.LastName = updateAuthor.LastName;
            }
            else
            {
                return NotFound("NotFound");
            }

            return Ok();
        }

        [HttpDelete]
        [Route("authors/{id}")]
        public ActionResult Remove(int id)
        {
            var existingAuthor = _authors.FirstOrDefault(c => c.Id == id);

            if (existingAuthor != null)
            {
                var authorToRemove = _authors.Single(r => r.Id == id);
                _authors.Remove(authorToRemove);
            }
            else
            {
                return NotFound("NotFound");
            }

            return NoContent();
        }
    }
}
