using System.Security.Claims;

namespace BooksReviewAPI.Services
{
    public interface IUserService
    {
        public dynamic ValidateToken(ClaimsIdentity identity);
    }
}
