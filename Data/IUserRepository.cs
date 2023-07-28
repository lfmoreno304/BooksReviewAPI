using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IUserRepository
    {
        Task<Users> GetUser(int id);
        Task<Users> GetUserByEmailAndPassword(string email,string password);
        Task<bool> InsertUser(Users user);
        Task<bool> UpdateUser(Users user);
        Task<bool> DeleteUser(Users user);
    }
}
