﻿using System.Collections.Generic;
using Martium.BookLovers.Api.Contracts.Request;
using Martium.BookLovers.Api.Contracts.Response;
using Martium.BookLovers.Api.Host.Repositories;
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

        private readonly AuthorRepository _authorRepository = new AuthorRepository();

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("authors")]
        public ActionResult<IEnumerable<AuthorReadModel>> GetList()
        {
            List<AuthorReadModel> authors = _authorRepository.GetAuthors();

            return Ok(authors);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("authors/{id}")]
        public ActionResult<AuthorReadModel> GetById(int id)
        {
            var author = _authorRepository.GetAuthorById(id);

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
            int id = _authorRepository.CreateNewAuthor(authorRequest);

            var newAuthor = _authorRepository.GetAuthorById(id);

            return CreatedAtAction(nameof(GetById), new { id }, newAuthor);  
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("authors/{id}")]
        public ActionResult<AuthorReadModel> Update([FromBody] AuthorModel authorUpdate, int id)
        {
            // Get authori by id if not found return not found error

            // updated

            _authorRepository.UpdateAuthorById(id, authorUpdate);

            /*if (isAuthorUpdatable == false)
            {
                return NotFound("authorNotFound");
            }*/

            // get author by id and return in OK

            //return Ok(isAuthorUpdatable);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Route("authors/{id}")]
        public ActionResult Delete(int id)
        {
            _authorRepository.DeleteAuthorById(id);

            return NoContent();
        }
    }
}
