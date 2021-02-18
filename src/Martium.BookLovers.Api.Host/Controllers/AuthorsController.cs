using System.Collections.Generic;
using System.Linq;
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
            /*if (id > _authors.Count || id <= 0)
            {
                return BadRequest($"Bad Author Id (must be in the range 1 - {_authors.Count})");
            }*/

            AuthorReadModel author = _authors.FirstOrDefault(x => x.Id == id);

            // ar rado ar ne ? ir jei nerado tada grazini NotFound

            return Ok(author);
        }

        [HttpPost]
        [Route("authors")]
        public ActionResult Create([FromBody] AuthorReadModel newAuthorRequest)
        {
            int newId = _authors.Max(x => x.Id) + 1;

            var newAuthor = new AuthorReadModel
            {
                Id = newId, 
                FirstName = newAuthorRequest.FirstName, 
                LastName = newAuthorRequest.LastName
            };

            _authors.Add(newAuthor);

            return CreatedAtAction(nameof(GetAuthor), new { id = newId }, newAuthor);
        }
    }
}
