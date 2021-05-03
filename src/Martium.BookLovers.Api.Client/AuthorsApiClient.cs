using System.Collections.Generic;
using System.Linq;
using Martium.BookLovers.Api.Contracts.Request;
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

        public AuthorReadModel GetAuthor(int id)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = $"v1/bookLovers/authors/{id}"
            };

            var response = _restClient.Execute<AuthorReadModel>(request);

            return response.IsSuccessful ? response.Data : new AuthorReadModel();
        }

        public bool CreateNewAuthor(AuthorModel createNewAuthor)
        {
            bool isCreated;

            var request = new RestRequest(Method.POST)
            {
                Resource = "v1/bookLovers/authors",
            };

            request.AddJsonBody(createNewAuthor);
            request.RequestFormat = DataFormat.Json;

           var response = _restClient.Post(request);

           isCreated = response.IsSuccessful;

           return isCreated;
        }

        public bool UpdateAuthorById(AuthorModel updateAuthor, int id)
        {
            bool isUpdated;

            var request = new RestRequest(Method.PUT)
            {
                Resource = $"v1/bookLovers/authors/{id}"
            };

            request.AddJsonBody(updateAuthor);
            request.RequestFormat = DataFormat.Json;

            var response = _restClient.Execute<AuthorReadModel>(request);

            isUpdated = response.IsSuccessful;

            return isUpdated;
        }
    }
}
