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
    public class UserRepository: IUserRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public UserRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {

            return new MySqlConnection(_connectionString.ConnectionString);

        }
        public async Task<Users> GetUser(int Id)
        {
            var db = dbConnection();
            var sql = @"SELECT user_id,email,password,img FROM users WHERE user_id = @id";
            return await db.QueryFirstOrDefaultAsync<Users>(sql, new { id = Id });
        }

        public async Task<bool> InsertUser(Users user)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO users(email, password, img)
                        VALUES(@email, @password, @img)";

            var result = await db.ExecuteAsync(sql, new
            { user.email, user.password, user.img });

            return result > 0;
        }

        public async Task<bool> UpdateUser(Users user)
        {
            var db = dbConnection();
            var sql = @"UPDATE users SET email=@email,
                        password=@password, 
                        img= @img WHERE user_id = @id ";

            var result = await db.ExecuteAsync(sql, new
            { user.email, user.password, user.img,user.User_id });

            return result > 0;
        }

        public async Task<bool> DeleteUser(Users user)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM user WHERE user_id = @id";
            var result = await db.ExecuteAsync(sql, new { id = user.User_id });
            return result > 0;
        }

        public async Task<Users> GetUserByEmailAndPassword(string Email, string Password)
        {
            var db = dbConnection();
            var sql = @"SELECT user_id,email,password,img FROM users WHERE email = @email AND password = @password";
            return await db.QueryFirstOrDefaultAsync<Users>(sql, new { email = Email,password = Password});
        }
    }
}
