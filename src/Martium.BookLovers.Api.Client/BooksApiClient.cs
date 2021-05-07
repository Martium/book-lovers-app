using System.Collections.Generic;
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
    }
}
