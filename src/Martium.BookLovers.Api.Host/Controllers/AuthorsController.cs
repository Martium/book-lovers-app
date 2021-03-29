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
            AuthorReadModel author = _authorRepository.GetAuthorById(id);

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

            AuthorReadModel newAuthor = _authorRepository.GetAuthorById(id);

            return CreatedAtAction(nameof(GetById), new { id }, newAuthor);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("authors/{id}")]
        public ActionResult<AuthorReadModel> Update([FromBody] AuthorModel authorUpdate, int id)
        {
            AuthorReadModel existingAuthor = _authorRepository.GetAuthorById(id);

            if (existingAuthor == null)
            {
                return NotFound("authorNotFound");
            }

            _authorRepository.UpdateAuthorById(id, authorUpdate);

            var updatedAuthor = _authorRepository.GetAuthorById(id);

            return Ok(updatedAuthor);
        }           

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Route("authors/{id}")]
        public ActionResult Delete(int id)
        {
            AuthorReadModel existingAuthor = _authorRepository.GetAuthorById(id);

            if (existingAuthor == null)
            {
                return NotFound("authorNotFound");
            }

            _authorRepository.DeleteAuthorById(id);

            return NoContent();
        }
    }
}
