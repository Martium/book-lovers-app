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

                string getExistingAuthorsCommand =
                    @"SELECT *
                      FROM Authors
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
                        A.Id = @Id
                     ";

                object queryParameter = new 
                {
                    Id = id
                };

                try
                {
                    AuthorReadModel getAuthor = dbConnection.QuerySingle<AuthorReadModel>(getExistingAuthorCommand, queryParameter);
                    return getAuthor;
                }
                catch 
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

                string getBiggestIdNumberCommand =
                    @"SELECT
                        MAX(A.Id)
                      FROM Authors A
                     ";


                int? biggestAuthorId = dbConnection.QuerySingle<int?>(getBiggestIdNumberCommand) ?? 0;

                return biggestAuthorId.Value + 1;
            }
        }

        public bool CreateNewAuthor(AuthorModel newAuthor)
        {
            int newAuthorId = GetIdForNewAuthor();

            using (SQLiteConnection dbConnection = new SQLiteConnection(DatabaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string createNewAuthorCommand =
                    @"INSERT INTO 'Authors'
                        VALUES (
                            @Id , @FirstName , @LastName 
                        )
                     "; 

                object queryParameters = new
                {
                    Id = newAuthorId, newAuthor.FirstName, newAuthor.LastName
                };

                int affectedRows = dbConnection.Execute(createNewAuthorCommand, queryParameters);

                return affectedRows == 1;
            }
        }

        public bool UpdateAuthorById(int id, AuthorModel updateAuthor)
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection(DatabaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string updateAuthorCommand =
                    @"UPDATE 'AUTHORS'
                        SET FirstName = @FirstName , LastName = @LastName
                      WHERE Id = @Id
                     ";

                object queryParameters = new
                {
                    Id = id, updateAuthor.FirstName, updateAuthor.LastName
                };

                try
                {
                    int affectedRows = dbConnection.Execute(updateAuthorCommand, queryParameters);
                    return affectedRows == 1;
                }
                catch
                {
                    bool authorExists = false;
                    return authorExists;
                }
            }
        }

        public bool DeleteAuthorById(int id)
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection(DatabaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string deleteAuthorCommand =
                    @"DELETE 'Authors'
                      WHERE Id = @Id
                      DELETE 'Books'
                      WHERE AuthorId = @Id  
                     ";

                object queryParameters = new
                {
                    Id = id
                };

                try
                {
                    int affectedRows = dbConnection.Execute(deleteAuthorCommand, queryParameters);
                    return affectedRows == 1;
                }
                catch 
                {
                    bool authorExists = false;
                    return authorExists;
                }
            }
        }

    }
}
