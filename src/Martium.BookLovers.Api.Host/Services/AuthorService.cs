using System.Collections.Generic;
using Martium.BookLovers.Api.Contracts.Request;
using Martium.BookLovers.Api.Contracts.Response;
using Martium.BookLovers.Api.Host.Errors.Exceptions;
using Martium.BookLovers.Api.Host.Repositories;

namespace Martium.BookLovers.Api.Host.Services
{
    public class AuthorService 
    {
        private readonly AuthorRepository _authorRepository = new AuthorRepository();

        public List<AuthorReadModel> GetAuthorsList()
        {
            List<AuthorReadModel> authors = _authorRepository.GetAuthors();

            return authors;
        }

        public AuthorReadModel GetAuthorById(int id)
        {
            AuthorReadModel author = _authorRepository.GetAuthorById(id);

            if (author == null)
            {
                throw new AuthorNotFoundException();
            }

            return author;
        }

        public int CreateNewAuthorId(AuthorModel author)
        {
            int id = _authorRepository.CreateNewAuthor(author);

            return id;
        }

        public AuthorReadModel UpdateAuthor(AuthorModel authorUpdate, int id)
        {
            AuthorReadModel existingAuthor = _authorRepository.GetAuthorById(id);

            if (existingAuthor == null)
            {
                throw new AuthorNotFoundException();
            }

            _authorRepository.UpdateAuthorById(id, authorUpdate);

            AuthorReadModel updatedAuthor = _authorRepository.GetAuthorById(id);

            return updatedAuthor;
        }

        public void DeleteAuthor(int id)
        {
            AuthorReadModel existingAuthor = _authorRepository.GetAuthorById(id);

            if (existingAuthor == null)
            {
                throw new AuthorNotFoundException();
            }

            _authorRepository.DeleteAuthorById(id);
        }
    }
}
