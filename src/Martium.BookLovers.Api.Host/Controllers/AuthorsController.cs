using System.Collections.Generic;
using Martium.BookLovers.Api.Contracts.Response;
using Microsoft.AspNetCore.Mvc;

namespace Martium.BookLovers.Api.Host.Controllers
{
    [ApiController]
    [Route("v1/bookLovers")]

    public class AuthorsController : ControllerBase
    {
        private readonly List<AuthorReadModel> _authors = new List<AuthorReadModel>
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
        [Route("author/{id}")]
        public ActionResult<AuthorReadModel> GetAuthor(int id)
        {
            if (id > _authors.Count)
            {
                return BadRequest($"Bad Author Id (must be in the range 1 - {_authors.Count})");
            }

            var author = _authors[id - 1];
            return Ok(author);
        }


    }
}
