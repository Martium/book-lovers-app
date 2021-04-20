using System.Collections.Generic;
using Martium.BookLovers.Api.Contracts.Request;
using Martium.BookLovers.Api.Contracts.Response;
using Martium.BookLovers.Api.Host.Constants;
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

        public AuthorReadModel CreateNewAuthor(AuthorModel authorRequest)
        {
            CheckAuthorNameLength(authorRequest);

            int id = _authorRepository.CreateNewAuthor(authorRequest);

            AuthorReadModel newAuthor = FillNewAuthorInfo(authorRequest, id);

            return newAuthor;
        }

        public AuthorReadModel UpdateAuthor(AuthorModel authorUpdate, int id)
        {
            CheckId(id);
            CheckAuthorNameLength(authorUpdate);

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

        private void CheckId(int id)
        {
            AuthorReadModel existingAuthor = _authorRepository.GetAuthorById(id);

            if (existingAuthor == null)
            {
                throw new AuthorNotFoundException();
            }
        }

        private AuthorReadModel FillNewAuthorInfo(AuthorModel authorRequest, int id)
        {
            AuthorReadModel newAuthorInfo = new AuthorReadModel()
            {
                Id = id,
                FirstName = authorRequest.FirstName,
                LastName = authorRequest.LastName
            };

            return newAuthorInfo;
        }

        private void CheckAuthorNameLength(AuthorModel authorRequest)
        {
            if (authorRequest.FirstName.Length > BookLoversSettings.AuthorLengths.FirstName && authorRequest.LastName.Length > BookLoversSettings.AuthorLengths.LastName)
            {
                throw new BadRequestException("MaxLengthExceeds", "The size of the Author First Name and Last name exceeds the maximum size permitted.");
            }

            if (authorRequest.FirstName.Length > BookLoversSettings.AuthorLengths.FirstName)
            {
                throw new BadRequestException("MaxLengthExceeds", "The size of the Author First Name exceeds the maximum size permitted.");
            }

            if (authorRequest.LastName.Length > BookLoversSettings.AuthorLengths.LastName)
            {
                throw new BadRequestException("MaxLengthExceeds", "The size of the Author Last Name exceeds the maximum size permitted.");
            }
        }
    }
}
