using Dapper;
using DB;
using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ReviewRepository: IReviewRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public ReviewRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {

            return new MySqlConnection(_connectionString.ConnectionString);

        }

        public async Task<bool> DeleteReview(Review review,int userid)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM reviews WHERE review_id = @id AND user_id = @user";
            var result = await db.ExecuteAsync(sql, new { id = review.Review_id, user = userid});
            return result > 0;
        }

        public async Task<Review> GetDetails(int Id)
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM reviews WHERE review_id = @id";

            return await db.QueryFirstOrDefaultAsync<Review>(sql, new { id = Id });
        }

        public async Task<IEnumerable<Review>> GetReviews()
        {
            var db = dbConnection();
            var sql = @"SELECT *  FROM reviews";

            return await db.QueryAsync<Review>(sql, new { });
        }

        public async Task<bool> InsertReview(Review review)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO reviews(description, rating, user_id, book_id)
                        VALUES(@description, @rating, @user_id, @book_id)";

            var result = await db.ExecuteAsync(sql, new
            { review.Description, review.Rating, review.User_id, review.Book_id });

            return result > 0;
        }

        public async Task<bool> UpdateReview(Review review)
        {
            var db = dbConnection();
            var sql = @"UPDATE reviews SET description=@description,
                        rating=@rating, 
                        user_id=@user_id, 
                        book_id= @book_id WHERE review_id = @id ";

            var result = await db.ExecuteAsync(sql, new
            { review.Description, review.Rating, review.User_id, review.Book_id, review.Review_id });

            return result > 0;
        }

        public  async Task<IEnumerable<ReviewDetail>> GetBooksReviews(int Id)
        {
            var db = dbConnection();
            var sql = @"SELECT r.review_id, r.description, r.rating, u.email AS user_email, r.book_id 
                        FROM reviews r
                        JOIN users u ON r.user_id = u.user_id WHERE r.book_id = @id";

            return await db.QueryAsync<ReviewDetail>(sql, new { id = Id });
        }

        public async Task<IEnumerable<Review>> GetUsersReviews(int Id)
        {
            var db = dbConnection();
            var sql = @"SELECT *  FROM reviews WHERE user_id = @id";

            return await db.QueryAsync<Review>(sql, new { id = Id });
        }
    }
}
