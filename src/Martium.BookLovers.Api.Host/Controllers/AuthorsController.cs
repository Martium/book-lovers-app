using System.Collections.Generic;
using Martium.BookLovers.Api.Contracts.Request;
using Martium.BookLovers.Api.Contracts.Response;
using Martium.BookLovers.Api.Host.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Martium.BookLovers.Api.Host.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("v1/bookLovers")]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _authorService = new AuthorService();

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("authors")]
        public ActionResult<IEnumerable<AuthorReadModel>> GetList()
        {
            List<AuthorReadModel> authors = _authorService.GetAuthorsList();

            return Ok(authors);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("authors/{id}")]
        public ActionResult<AuthorReadModel> GetById(int id)
        {
            AuthorReadModel author = _authorService.GetAuthorById(id);

            return Ok(author);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("authors")]
        public ActionResult<AuthorReadModel> Create([FromBody] AuthorModel authorRequest)
        {
            AuthorReadModel newAuthor = _authorService.CreateNewAuthor(authorRequest);

            return CreatedAtAction(nameof(GetById), new { newAuthor.Id }, newAuthor);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("authors/{id}")]
        public ActionResult<AuthorReadModel> Update([FromBody] AuthorModel authorUpdate, int id)
        {
            AuthorReadModel updatedAuthor = _authorService.UpdateAuthor(authorUpdate, id);

            return Ok(updatedAuthor);
        }           

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Route("authors/{id}")]
        public ActionResult Delete(int id)
        {
            _authorService.DeleteAuthor(id);

            return NoContent();
        }
    }
}
