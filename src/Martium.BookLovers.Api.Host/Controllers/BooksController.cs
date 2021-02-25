﻿using System;
using System.Collections.Generic;
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
    public class BooksController : ControllerBase
    {
        public static List<BookReadModel> Books = new List<BookReadModel>()
        {
            new BookReadModel { AuthorId = AuthorsController.Authors[0].Id, Id = 1, BookName = "Harry Potter and the Philosopher's Stone", ReleaseYear = 1997 },
            new BookReadModel { AuthorId = AuthorsController.Authors[0].Id, Id = 2, BookName = "Harry Potter and the Chamber of Secrets", ReleaseYear =  1998 },
            new BookReadModel { AuthorId = AuthorsController.Authors[0].Id, Id = 3, BookName = "Harry Potter and the Prisoner of Azkaban", ReleaseYear = 1999 },

            new BookReadModel { AuthorId = AuthorsController.Authors[1].Id, Id = 4, BookName = "A Game of Thrones", ReleaseYear = 1996 },
            new BookReadModel { AuthorId = AuthorsController.Authors[1].Id, Id = 5, BookName = "A Clash of Kings", ReleaseYear = 1998 },
            new BookReadModel { AuthorId = AuthorsController.Authors[1].Id, Id = 6, BookName = "A Storm of Swords", ReleaseYear = 2000 }
        };

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("books")]
        public ActionResult<IEnumerable<AuthorReadModel>> GetList([FromQuery] int? authorId)
        {
            if (authorId == null)
            {
                return Ok(Books);
            }
            else if (!AuthorsController.Authors.Exists(c => c.Id == authorId))
            {
                return NotFound("authorNotFound");
            }

            List<BookReadModel> authorBooks = Books.FindAll(c => c.AuthorId == authorId);

            return Ok(authorBooks);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("books/{id}")]
        public ActionResult<IEnumerable<AuthorReadModel>> GetAuthorBook(int id)
        {
            BookReadModel book = Books.FirstOrDefault(y => y.Id == id);

            if (book == null)
            {
                return NotFound("bookNotFound");
            }

            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("books/author/{authorId}")]
        public ActionResult<AuthorReadModel> CreateAuthorBook(int authorId, [FromBody] BookModel book)
        {
            AuthorReadModel author = AuthorsController.Authors.FirstOrDefault(x => x.Id == authorId);

            if (author == null)
            {
                return NotFound("authorNotFound");
            }

            int newBookId = Books.Max(x => x.Id) + 1;

            var newBook = new BookReadModel()
            {
                AuthorId = authorId,
                Id = newBookId,
                BookName = book.BookName,
                ReleaseYear = book.ReleaseYear
            };

            Books.Add(newBook);

            return CreatedAtAction(nameof(CreateAuthorBook), new {newBookId}, newBook);
        }

        
    }
}
