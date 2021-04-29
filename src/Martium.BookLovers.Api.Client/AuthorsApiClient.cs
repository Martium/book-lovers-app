using System.Collections.Generic;
using Martium.BookLovers.Api.Contracts.Response;
using RestSharp;

namespace Martium.BookLovers.Api.Client
{
    public class AuthorsApiClient
    {
        private readonly RestClient _restClient;

        public AuthorsApiClient()
        {
            _restClient = new RestClient("http://localhost:5000/");
        }

        public List<AuthorReadModel> GetAuthors()
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = "v1/bookLovers/authors"
            };

            var response = _restClient.Execute<List<AuthorReadModel>>(request);

            return response.IsSuccessful 
                ? response.Data 
                : new List<AuthorReadModel>();
        }
    }
}
