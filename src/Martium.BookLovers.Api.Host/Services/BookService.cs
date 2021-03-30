﻿using System.Collections.Generic;
using Martium.BookLovers.Api.Contracts.Request;
using Martium.BookLovers.Api.Contracts.Response;
using Martium.BookLovers.Api.Host.Errors.Exceptions;
using Martium.BookLovers.Api.Host.Repositories;

namespace Martium.BookLovers.Api.Host.Services
{
    public class BookService
    {
        private readonly AuthorRepository _authorRepository = new AuthorRepository();

        private readonly BookRepository _bookRepository = new BookRepository();

        public List<BookReadModel> GetList(int? authorId)
        {
            List<BookReadModel> books = new List<BookReadModel>();

            books = authorId.HasValue
                ? _bookRepository.GetAllAuthorsBooks(authorId.Value)
                : _bookRepository.GetAllBooks();

            return books;
        }

        public BookReadModel GetBookById(int id)
        {
            BookReadModel book = _bookRepository.GetBookById(id);

            if (book == null)
            {
                throw new BookNotFoundException();
            }

            return book;
        }

        private void CheckAuthorId(BookModel checkAuthorId)
        {
            AuthorReadModel authorById = _authorRepository.GetAuthorById(checkAuthorId.AuthorId);

            if (authorById == null)
            {
                throw new AuthorBadRequestException();
            }
        }

        public int CreateNewBook(BookModel bookRequest)
        {
            CheckAuthorId(bookRequest);

            int id = _bookRepository.CreateNewBook(bookRequest);

            return id;
        }

        public BookReadModel UpdateNewBook(BookModel updateBook, int id)
        {
            CheckAuthorId(updateBook);

            GetBookById(id);

            _bookRepository.UpdateBookById(id, updateBook);

            BookReadModel updatedBook = _bookRepository.GetBookById(id);

            return updatedBook;
        }

        public void DeleteBookById(int id)
        {
            BookReadModel bookById = _bookRepository.GetBookById(id);

            if (bookById == null)
            {
                throw new BookNotFoundException();
            }

            _bookRepository.DeleteBookById(id);
        }
    }
}
