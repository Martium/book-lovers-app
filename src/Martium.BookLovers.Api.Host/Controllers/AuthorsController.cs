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
        public ActionResult<IEnumerable<AuthorReadModel>> GetAll()
        {
            return Ok(_authors);
        }
    }
}
