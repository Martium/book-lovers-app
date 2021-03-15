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

#if DEBUG
                FillDefaultInfoToBookLoversAuthorTable(dbConnection);

                FillDefaultInfoToBookLoversBookTable(dbConnection);
#endif
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
            string dropAuthorTableQuery = GetDropTableQuery("Authors");
            SQLiteCommand dropAuthorTableCommand = new SQLiteCommand(dropAuthorTableQuery, dbConnection);
            dropAuthorTableCommand.ExecuteNonQuery();

            string createAuthorTableQuery =
                $@"                  
                  CREATE TABLE [Authors] (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    [FirstName] [nvarchar]({BookLoversSettings.AuthorLengths.FirstName}) NOT NULL,
                    [LastName] [nvarchar]({BookLoversSettings.AuthorLengths.LastName}) NOT NULL,
                    UNIQUE(Id)
                  );
                ";

            SQLiteCommand createAuthorTableCommand = new SQLiteCommand(createAuthorTableQuery, dbConnection);
            createAuthorTableCommand.ExecuteNonQuery();
        }

        private void CreateBookTable(SQLiteConnection dbConnection)
        {
            string dropBookTableQuery = GetDropTableQuery("Books");
            SQLiteCommand dropBookTableCommand = new SQLiteCommand(dropBookTableQuery,dbConnection);
            dropBookTableCommand.ExecuteNonQuery();

            string createBookTableQuery =
                $@"                  
                  CREATE TABLE [Books] (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    [AuthorId] [INTEGER] NOT NULL,
                    [BookName] [nvarchar]({BookLoversSettings.BookLengths.BookName}) NOT NULL,
                    [ReleaseYear] [INTEGER] NOT NULL,
                    FOREIGN KEY (AuthorId) REFERENCES Author (Id),
                    UNIQUE(Id)
                  );
                ";

            SQLiteCommand createBookTableCommand = new SQLiteCommand(createBookTableQuery, dbConnection);
            createBookTableCommand.ExecuteNonQuery();
        }

        private void FillDefaultInfoToBookLoversAuthorTable(SQLiteConnection dbConnection)
        {
            string fillInfoToAuthorTable =
                $@"BEGIN TRANSACTION;
	                INSERT INTO 'Authors' 
	                    VALUES (NULL, 'Joanne', 'Rowling');
	                INSERT INTO 'Authors'
                        VALUES (NULL, 'George', 'Raymond Richard Martin');
                COMMIT;";

            SQLiteCommand fillAuthorInfoCommand = new SQLiteCommand(fillInfoToAuthorTable, dbConnection);
            fillAuthorInfoCommand.ExecuteNonQuery();
        }

        private void FillDefaultInfoToBookLoversBookTable(SQLiteConnection dbConnection)
        {
            string fillInfoToBookTable =
                $@"BEGIN TRANSACTION;
	                INSERT INTO 'Books' 
	                    VALUES (NULL, 1, 'Harry Potter and the Philosopher's Stone', 1997);
	                INSERT INTO 'Books'
                        VALUES (NULL, 1, 'Harry Potter and the Chamber of Secrets', '1988');
                    INSERT INTO 'Books' 
	                    VALUES (NULL, 1, 'Harry Potter and the Prisoner of Azkaban', '1999');
                    INSERT INTO 'Books' 
	                    VALUES (NULL, 2, 'A Game of Thrones', 1996);
                    INSERT INTO 'Books' 
	                    VALUES (NULL, 2, 'A Clash of Kings', 1988);
                    INSERT INTO 'Books' 
	                    VALUES (NULL, 2, 'A Storm of Swords', 2000);
                COMMIT;";
        }

        private string GetDropTableQuery(string tableName)
        {
            return $"DROP TABLE IF EXISTS [{tableName}]";
        }
    }
}