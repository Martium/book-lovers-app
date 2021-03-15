using System;
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
                      FROM Authors
                    ";

                IEnumerable<AuthorReadModel> getAllAuthors = dbConnection.Query<AuthorReadModel>(getExistingAuthors);
                return getAllAuthors.ToList();
            }
        }

        public AuthorReadModel GetAuthorById(int id)
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection(DatabaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string getExistingAuthor =
                    @"SELECT
                        A.Id , A.FirstName , A.LastName
                      FROM Authors A
                      WHERE
                        A.Id = @Id
                     ";

                object queryParameter = new 
                {
                    Id = id
                };

                try
                {
                    AuthorReadModel getAuthor = dbConnection.QuerySingle<AuthorReadModel>(getExistingAuthor, queryParameter);
                    return getAuthor;
                }
                catch (Exception e)
                {
                    AuthorReadModel authorNotExists = null;
                    return authorNotExists;
                }

            }
        }
    }
}
