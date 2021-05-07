using System.Collections.Generic;
using Martium.BookLovers.Api.Contracts.Request;
using Martium.BookLovers.Api.Contracts.Response;
using RestSharp;

namespace Martium.BookLovers.Api.Client
{
    public class BooksApiClient
    {
        private readonly RestClient _restClient;

        public BooksApiClient()
        {
            _restClient = new RestClient("http://localhost:5000/");
        }

        public List<BookReadModel> GetBooks(int? authorId)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = $"v1/bookLovers/books?authorId={authorId}"
            };

            var response = _restClient.Execute<List<BookReadModel>>(request);

            return response.IsSuccessful ? response.Data : new List<BookReadModel>();

        }

        public BookReadModel GetBookByBookId(int id)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = $"v1/bookLovers/books/{id}"
            };

            var response = _restClient.Execute<BookReadModel>(request);

            return response.IsSuccessful ? response.Data : null;
        }

        public bool CreateNewAuthor(BookModel createNewBook)
        {
            bool isCreated;

            var request = new RestRequest(Method.POST)
            {
                Resource = "v1/bookLovers/books",
            };

            request.AddJsonBody(createNewBook);
            request.RequestFormat = DataFormat.Json;

            var response = _restClient.Post(request);

            isCreated = response.IsSuccessful;

            return isCreated;
        }

        public bool UpdateBookById(BookModel updateBook, int id)
        {
            bool isUpdated;

            var request = new RestRequest(Method.PUT)
            {
                Resource = $"v1/bookLovers/books/{id}"
            };

            request.AddJsonBody(updateBook);
            request.RequestFormat = DataFormat.Json;

            var response = _restClient.Execute<BookModel>(request);

            isUpdated = response.IsSuccessful;

            return isUpdated;
        }

        public bool DeleteBookById(int id)
        {
            bool isDeleted;

            var request = new RestRequest(Method.DELETE)
            {
                Resource = $"v1/bookLovers/books/{id}"
            };

            var response = _restClient.Execute(request);

            isDeleted = response.IsSuccessful;

            return isDeleted;
        }
    }
}
