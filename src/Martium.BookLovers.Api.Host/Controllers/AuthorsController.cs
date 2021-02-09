using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Martium.BookLovers.Api.Host.Controllers
{
    [ApiController]
    [Route("v1/bookLovers/authors")]

    public class AuthorsController : ControllerBase
    {
        [HttpGet]

        public ActionResult<IEnumerable<string>> GetAll()
        {
            return new string[] { "J. K. Rowling", "George R. R. Martin" };
        }
    }
}
