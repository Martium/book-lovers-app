using Dapper;
using Martium.BookLovers.Api.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace Martium.BookLovers.Api.Host.Repositories
{
    public class BookRepository
    {
        public List<BookReadModel> GetAllBooks()
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection(DatabaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string getExistingBooksCommand =
                    @"SELECT *
                      FROM Books;
                    ";

                IEnumerable<BookReadModel> getAllBooks = dbConnection.Query<BookReadModel>(getExistingBooksCommand);
                return getAllBooks.ToList();
            }
        }

        public List<BookReadModel> GetAllAuthorsBooks(int authorId)
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection(DatabaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string getExistingBooksCommand =
                    @"SELECT *
                      FROM Books
                      WHERE AuthorId = @AuthorId
                    ";

                object queryParameters = new
                {
                    AuthorId = authorId
                };

                IEnumerable<BookReadModel> getAllAuthorsBooks = dbConnection.Query<BookReadModel>(getExistingBooksCommand, queryParameters);
                return getAllAuthorsBooks.ToList();
            }
        }

        public BookReadModel GetBookById(int id)
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection(DatabaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string getExistingBookCommand =
                    @"SELECT
                        B.Id , B.AuthorId, B.BookName , B.ReleaseYear
                      FROM Books B
                      WHERE
                        B.Id = @Id;
                     ";

                object queryParameter = new
                {
                    Id = id
                };

                BookReadModel getBook = dbConnection.QuerySingle<BookReadModel>(getExistingBookCommand, queryParameter);
                return getBook;
            }
        }

        public bool CheckAuthorId(int authorId)
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection(DatabaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string chechAuthorIdCommand =
                    @"SELECT
                        B.AuthorId
                      FROM Books B
                      WHERE
                        EXISTS (
                            SELECT
                                1
                            FROM
                                Books
                            WHERE
                                AuthorId = @AuthorId
                        );
                     ";

                object queryParameters = new
                {
                    AuthorId = authorId
                };

                bool isIdExists = dbConnection.ExecuteScalar<bool>(chechAuthorIdCommand, queryParameters);

                return isIdExists;
            }
        }

        public bool CheckBookId(int id)
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection(DatabaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string chechAuthorIdCommand =
                    @"SELECT
                        B.Id
                      FROM Books B
                      WHERE
                        EXISTS (
                            SELECT
                                1
                            FROM
                                Books
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
