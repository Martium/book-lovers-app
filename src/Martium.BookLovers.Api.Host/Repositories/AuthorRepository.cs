using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using Martium.BookLovers.Api.Contracts.Request;
using Martium.BookLovers.Api.Contracts.Response;

namespace Martium.BookLovers.Api.Host.Repositories
{
    public class AuthorRepository
    {
        public List<AuthorReadModel> GetAuthors()
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection(DatabaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string getExistingAuthorsCommand =
                    @"SELECT *
                      FROM Authors;
                    ";

                IEnumerable<AuthorReadModel> getAllAuthors = dbConnection.Query<AuthorReadModel>(getExistingAuthorsCommand);
                return getAllAuthors.ToList();
            }
        }

        public AuthorReadModel GetAuthorById(int id)
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection(DatabaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string getExistingAuthorCommand =
                    @"SELECT
                        A.Id , A.FirstName , A.LastName
                      FROM Authors A
                      WHERE
                        A.Id = @Id;
                     ";

                object queryParameter = new 
                {
                    Id = id
                };

                AuthorReadModel getAuthor = dbConnection.QuerySingleOrDefault<AuthorReadModel>(getExistingAuthorCommand, queryParameter);
                return getAuthor;
            }
        }

        public int CreateNewAuthor(AuthorModel newAuthor)
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection(DatabaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string createNewAuthorCommand =
                    @"INSERT INTO 'Authors'
                       (FirstName, LastName)
                        VALUES (
                           @FirstName , @LastName 
                        );
                      SELECT last_insert_rowid();
                     "; 

                object queryParameters = new
                {
                    newAuthor.FirstName, newAuthor.LastName
                };

                int id = dbConnection.ExecuteScalar<int>(createNewAuthorCommand, queryParameters);

                return id;
            }
        }

        public void UpdateAuthorById(int id, AuthorModel updateAuthor)
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection(DatabaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string updateAuthorCommand =
                    @"UPDATE 'AUTHORS'
                        SET FirstName = @FirstName , LastName = @LastName
                      WHERE Id = @Id;
                     ";

                object queryParameters = new
                {
                    Id = id, updateAuthor.FirstName, updateAuthor.LastName
                };

                dbConnection.Execute(updateAuthorCommand, queryParameters);
            }
        }

        public void DeleteAuthorById(int id)
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection(DatabaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string deleteAuthorCommand =
                    @"DELETE 
                      FROM 'Authors'
                      WHERE Id = @Id;
                     ";

                object queryParameters = new
                {
                    Id = id
                };

                dbConnection.Execute(deleteAuthorCommand, queryParameters);
            }
        }

        public bool CheckAuthorId(int id)
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection(DatabaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string chechAuthorIdCommand =
                    @"SELECT
                        A.Id
                      FROM Authors A
                      WHERE
                        EXISTS (
                            SELECT
                                1
                            FROM
                                Authors
                            WHERE
                                Id = @Id
                        );
                     ";

                object queryParameters = new
                {
                    Id = id
                };

                bool isIdExists = dbConnection.ExecuteScalar<bool>(chechAuthorIdCommand, queryParameters);

                return isIdExists;
            }
        }
    }
}
