using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using 

namespace Martium.BookLovers.Api.Host.Controllers
{
    [ApiController]
    [Route("v1/bookLovers")]

    public class AuthorsController : ControllerBase
    {
        private readonly List<string> _authors = new List<string> () { "J. K. Rowling", "George R. R. Martin" };

        [HttpGet]
        [Route("authors")]

        public ActionResult<IEnumerable<string>> GetAll()
        {
            return _authors;
        }
    }
}
