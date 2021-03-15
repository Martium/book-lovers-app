using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using Martium.BookLovers.Api.Contracts.Request;
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

        private int GetIdForNewAuthor()
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection(DatabaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string getBiggestIdNumber =
                    @"SELECT
                        MAX(A.Id)
                      FROM Authors A
                     ";


                int? biggestAuthorId = dbConnection.QuerySingle<int?>(getBiggestIdNumber) ?? 0;

                return biggestAuthorId.Value + 1;
            }
        }

        public bool CreateNewAuthor(AuthorModel newAuthor)
        {
            int newAuthorId = GetIdForNewAuthor();

            using (SQLiteConnection dbConnection = new SQLiteConnection(DatabaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string createNewAuthor =
                    @"INSERT INTO 'Authors'
                        VALUES (
                            @Id, @FirstName, @LastName 
                        )
                     ";

                object queryParameters = new
                {
                    Id = newAuthorId, newAuthor.FirstName, newAuthor.LastName
                };

                int affectedRows = dbConnection.Execute(createNewAuthor, queryParameters);

                return affectedRows == 1;

            }
        }
    }
}
