using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Martium.BookLovers.Api.Host.Constants;

namespace Martium.BookLovers.Api.Host.Repositories
{
    public class DatabaseInitializerRepository
    {
        public void InitializeDatabaseIfNotExist()
        {
            if (File.Exists(DatabaseConfiguration.DatabaseFile))
            {
#if DEBUG

#else
                return;
#endif
            }

            if (!Directory.Exists(DatabaseConfiguration.DatabaseFolder))
            {
                Directory.CreateDirectory(DatabaseConfiguration.DatabaseFolder);
            }
            else
            {
                DeleteLeftoverFilesAndFolders();
            }

            SQLiteConnection.CreateFile(DatabaseConfiguration.DatabaseFile);

            using (SQLiteConnection dbConnection = new SQLiteConnection(DatabaseConfiguration.ConnectionString))
            {
                dbConnection.Open();

                CreateAuthorTable(dbConnection);

                CreateBookTable(dbConnection);

            }
        }

        private void DeleteLeftoverFilesAndFolders()
        {
            var directory = new DirectoryInfo(DatabaseConfiguration.DatabaseFolder);

            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo subDirectory in directory.GetDirectories())
            {
                subDirectory.Delete(true);
            }
        }

        private void CreateAuthorTable(SQLiteConnection dbConnection)
        {
            string dropAuthorTableQuery = GetDropTableQuery("Author");
            SQLiteCommand dropAuthorTableCommand = new SQLiteCommand(dropAuthorTableQuery, dbConnection);
            dropAuthorTableCommand.ExecuteNonQuery();

            string createAuthorTableQuery =
                $@"                  
                  CREATE TABLE [Author] (
                    [Id] [INTEGER] NOT NULL,
                    [FirstName] [nvarchar]({AuthorSettings.Lengths.FirstName}) NOT NULL,
                    [LastName] [nvarchar]({AuthorSettings.Lengths.LastName}) NOT NULL,
                    UNIQUE(Id)
                  );
                ";

            SQLiteCommand createAuthorTableCommand = new SQLiteCommand(createAuthorTableQuery, dbConnection);
            createAuthorTableCommand.ExecuteNonQuery();
        }

        private void CreateBookTable(SQLiteConnection dbConnection)
        {
            string dropBookTableQuery = GetDropTableQuery("Book");
            SQLiteCommand dropBookTableCommand = new SQLiteCommand(dropBookTableQuery,dbConnection);
            dropBookTableCommand.ExecuteNonQuery();

            string createBookTableQuery =
                $@"                  
                  CREATE TABLE [Book] (
                    [AuthorId] [INTEGER] NOT NULL,
                    [Id] [INTEGER] NOT NULL,
                    [BookName] [nvarchar]({BookSettings.Lengths.BookName}) NOT NULL,
                    [ReleaseYear] [INTEGER] NOT NULL,
                    UNIQUE(AuthorId, Id)
                  );
                ";
        }

        private string GetDropTableQuery(string tableName)
        {
            return $"DROP TABLE IF EXISTS [{tableName}]";
        }
    }
}