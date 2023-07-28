using Dapper;
using DB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BookRepository : IBookRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public BookRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection() {

            return new MySqlConnection(_connectionString.ConnectionString);

        }
        public async Task<bool> DeleteBook(Books book)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM books WHERE book_id = @id";
            var result = await db.ExecuteAsync(sql, new { id = book.Book_id });
            return result > 0;
        }

        public async Task<IEnumerable<Books>> GetBooks()
        {
            var db = dbConnection();
            var sql = @"SELECT *  FROM books";

            return await db.QueryAsync<Books>(sql, new { });
        }

        public async Task<Books> GetDetails(int Id)
        {
            var db = dbConnection();
            var sql = @"SELECT *  FROM books WHERE book_id = @id";

            return await db.QueryFirstOrDefaultAsync<Books>(sql, new {id = Id });
        }

        public async Task<bool> InsertBook(Books book)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO books(title, summary, category, img, author)
                        VALUES(@title, @summary, @category, @img, @author)";

            var result = await db.ExecuteAsync(sql, new 
            { book.Title, book.Summary, book.Category, book.Img, book.Author });

            return result > 0 ;
        }

        public async Task<bool> UpdateBook(Books book)
        {
            var db = dbConnection();
            var sql = @"UPDATE books SET title=@title,
                        summary=@summary, 
                        category=@category, 
                        img= @img,
                        author=@author WHERE book_id = @id ";

            var result = await db.ExecuteAsync(sql, new
            { book.Title, book.Summary, book.Category, book.Img, book.Author, book.Book_id });

            return result > 0;
        }
    }
}
