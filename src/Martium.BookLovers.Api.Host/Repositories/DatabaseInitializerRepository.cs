﻿using System;
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

                FillDefaultInfoToBookLoversAuthorTable(dbConnection);

                FillDefaultInfoToBookLoversBookTable(dbConnection);
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
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
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
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    [BookName] [nvarchar]({BookSettings.Lengths.BookName}) NOT NULL,
                    [ReleaseYear] [INTEGER] NOT NULL,
                    FOREIGN KEY (AuthorId) REFERENCES Author (Id),
                    UNIQUE(AuthorId, Id)
                  );
                ";

            SQLiteCommand createBookTableCommand = new SQLiteCommand(createBookTableQuery, dbConnection);
            createBookTableCommand.ExecuteNonQuery();
        }

        private void FillDefaultInfoToBookLoversAuthorTable(SQLiteConnection dbConnection)
        {
            string fillInfoToAuthorTable =
                $@"BEGIN TRANSACTION;
	                INSERT INTO 'Author' 
	                    VALUES (1, 'Joanne', 'Rowling');
	                INSERT INTO 'Author'
                        VALUES (2, 'George', 'Raymond Richard Martin');
                COMMIT;";

            SQLiteCommand fillAuthorInfoCommand = new SQLiteCommand(fillInfoToAuthorTable, dbConnection);
            fillAuthorInfoCommand.ExecuteNonQuery();
        }

        private void FillDefaultInfoToBookLoversBookTable(SQLiteConnection dbConnection)
        {
            string fillInfoToBookTable =
                $@"BEGIN TRANSACTION;
	                INSERT INTO 'Book' 
	                    VALUES (1, 1, 'Harry Potter and the Philosopher's Stone', 1997);
	                INSERT INTO 'Book'
                        VALUES (1, 2, 'Harry Potter and the Chamber of Secrets', '1988');
                    INSERT INTO 'Book' 
	                    VALUES (1, 3, 'Harry Potter and the Prisoner of Azkaban', '1999');
                    INSERT INTO 'Book' 
	                    VALUES (2, 4, 'A Game of Thrones', 1996);
                    INSERT INTO 'Book' 
	                    VALUES (2, 5, 'A Clash of Kings', 1988);
                    INSERT INTO 'Book' 
	                    VALUES (2, 6, 'A Storm of Swords', 2000);
                COMMIT;";
        }

        private string GetDropTableQuery(string tableName)
        {
            return $"DROP TABLE IF EXISTS [{tableName}]";
        }
    }
}