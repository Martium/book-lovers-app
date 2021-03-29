using Dapper;
using Martium.BookLovers.Api.Contracts.Response;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Martium.BookLovers.Api.Contracts.Request;

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

                BookReadModel getBook = dbConnection.QuerySingleOrDefault<BookReadModel>(getExistingBookCommand, queryParameter);
                return getBook;
            }
        }

        public int CreateNewBook(BookModel newBook)
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection(DatabaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string createNewBookCommand =
                    @"INSERT INTO 'Books'
                       (AuthorId, BookName, ReleaseYear)
                        VALUES (
                           @AuthorId , @BookName, @ReleaseYear 
                        );
                      SELECT last_insert_rowid();
                     ";

                object queryParameters = new
                {
                    newBook.AuthorId, newBook.BookName, newBook.ReleaseYear
                };

                int id = dbConnection.ExecuteScalar<int>(createNewBookCommand, queryParameters);
                return id;
            }
        }

        public void UpdateBookById(int id, BookModel updateBook)
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection(DatabaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string updateAuthorCommand =
                    @"UPDATE 'Books'
                        SET AuthorId = @AuthorId , BookName = @BookName , ReleaseYear = @ReleaseYear
                      WHERE Id = @Id;
                     ";

                object queryParameters = new
                {
                    Id = id, updateBook.AuthorId, updateBook.BookName, updateBook.ReleaseYear
                };

                dbConnection.Execute(updateAuthorCommand, queryParameters);
            }
        }

        public void DeleteBookById(int id)
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection(DatabaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                string deleteBookCommand =
                    @"DELETE 
                      FROM 'Books'
                      WHERE Id = @Id;
                     ";

                object queryParameters = new
                {
                    Id = id
                };

                dbConnection.Execute(deleteBookCommand, queryParameters);
            }
        }
    }
}
