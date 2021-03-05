using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using Martium.BookLovers.Api.Contracts.Response;

namespace Martium.BookLovers.Api.Host.Repositories
{
    public class BookLoversRepository
    {
        public List<AuthorReadModel> GetAuthors()
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection(DatabaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string getExistingAuthors =
                    @"SELECT *
                      FROM Author
                    ";

                IEnumerable<AuthorReadModel> getAllAuthors = dbConnection.Query<AuthorReadModel>(getExistingAuthors);
                return getAllAuthors.ToList();
            }
        }
    }
}
