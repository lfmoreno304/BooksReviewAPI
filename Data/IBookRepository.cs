using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IBookRepository
    {
        Task<IEnumerable<Books>> GetBooks();
        Task<Books> GetDetails(int id);
        Task<bool> InsertBook(Books book);
        Task<bool> UpdateBook(Books book);
        Task<bool> DeleteBook(Books book);
    }
}
