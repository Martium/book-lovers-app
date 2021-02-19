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

            if (!_authors.Exists(x => x.Id == id))
            {
                return NotFound("NotFound");
            }

            AuthorReadModel author = _authors.FirstOrDefault(x => x.Id == id);

            return Ok(author);
        }

        [HttpPost]
        [Route("authors")]
        public ActionResult Create([FromBody] NewAuthorReadModel newAuthorRequest)
        {
            int newId = _authors.Max(x => x.Id) + 1;

            var newAuthor = new AuthorReadModel()
            {
                Id = newId, 
                FirstName = newAuthorRequest.FirstName, 
                LastName = newAuthorRequest.LastName
            };

            _authors.Add(newAuthor);

            return CreatedAtAction(nameof(GetAuthor), new { id = newId }, newAuthor);
        }

        [HttpPut]
        [Route("authors/{id}")]
        public ActionResult Update([FromBody] NewAuthorReadModel updateAuthor, int id)
        {
            // if (!_authors.Exists(x => x.Id == id))
            // {
            //     return NotFound("NotFound");
            // }

            var existingAuthor = _authors.FirstOrDefault(c => c.Id == id);

            if (existingAuthor != null)
            {
                existingAuthor.FirstName = updateAuthor.FirstName;
                existingAuthor.LastName = updateAuthor.LastName;
            }

            return Ok();
        }

    }
}
