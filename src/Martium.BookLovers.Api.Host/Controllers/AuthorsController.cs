﻿using System.Collections.Generic;
using Martium.BookLovers.Api.Contracts.Response;
using Microsoft.AspNetCore.Mvc;

namespace Martium.BookLovers.Api.Host.Controllers
{
    [ApiController]
    [Route("v1/bookLovers")]

    public class AuthorsController : ControllerBase
    {
        private readonly List<Author> _authors = new List<Author>
        {
            new Author { Id = 1, FirstName = "Joanne", LastName =  "Rowling" },
            new Author { Id = 2, FirstName = "George", LastName = "Raymond Richard Martin" }
        };

        [HttpGet]
        [Route("authors")]

        public ActionResult<IEnumerable<Author>> GetAll()
        {
            return _authors;
        }
    }
}
