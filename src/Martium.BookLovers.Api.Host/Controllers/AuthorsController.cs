﻿using System.Collections.Generic;
using System.Linq;
using Martium.BookLovers.Api.Contracts.Request;
using Martium.BookLovers.Api.Contracts.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Martium.BookLovers.Api.Host.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("v1/bookLovers")]
    public class AuthorsController : ControllerBase
    {
        private static List<AuthorReadModel> _authors = new List<AuthorReadModel>
        {
            new AuthorReadModel { Id = 1, FirstName = "Joanne", LastName =  "Rowling" },
            new AuthorReadModel { Id = 2, FirstName = "George", LastName = "Raymond Richard Martin" }
        };

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("authors")]
        public ActionResult<IEnumerable<AuthorReadModel>> GetAuthorsList()
        {
            return Ok(_authors);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("authors/{id}")]
        public ActionResult<AuthorReadModel> GetAuthor(int id)
        {
            AuthorReadModel author = _authors.FirstOrDefault(x => x.Id == id);

            if (author == null)
            {
                return NotFound("authorNotFound");
            }

            return Ok(author);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("authors")]
        public ActionResult<AuthorReadModel> CreateAuthor([FromBody] AuthorModel authorRequest)
        {
            int id = _authors.Max(x => x.Id) + 1;

            var newAuthor = new AuthorReadModel()
            {
                Id = id, 
                FirstName = authorRequest.FirstName, 
                LastName = authorRequest.LastName
            };

            _authors.Add(newAuthor);

            return CreatedAtAction(nameof(GetAuthor), new { id }, newAuthor);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("authors/{id}")]
        public ActionResult<AuthorReadModel> UpdateAuthor([FromBody] AuthorModel authorUpdate, int id)
        {
            AuthorReadModel author = _authors.FirstOrDefault(c => c.Id == id);

            if (author == null)
            {
                return NotFound("authorNotFound");
            }

            author.FirstName = authorUpdate.FirstName;
            author.LastName = authorUpdate.LastName;

            return Ok(author);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Route("authors/{id}")]
        public ActionResult DeleteAuthor(int id)
        {
            AuthorReadModel author = _authors.FirstOrDefault(c => c.Id == id);

            if (author == null)
            {
                return NotFound("authorNotFound");
            }

            _authors.Remove(author);

            return NoContent();
        }
    }
}
