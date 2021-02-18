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
            if (id > _authors.Count || id <= 0)
            {
                return BadRequest($"Bad Author Id (must be in the range 1 - {_authors.Count})");
            }

            var author = _authors[id - 1];
            return Ok(author);
        }

        [HttpPost]
        [Route("new")]

        public ActionResult Create([FromBody] AuthorReadModel authorReadModel)
        {
            int newId = _authors.Count + 1;
            string firstName = "kazkas";
            string lastName = "niekas";

            _authors.Add(new AuthorReadModel {Id = newId, FirstName = firstName, LastName = lastName});

            return Created("v1/bookLovers", _authors);
        }
    }
}
