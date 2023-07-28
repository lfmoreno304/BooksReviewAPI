using Data;
using System.Security.Claims;

namespace BooksReviewAPI.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public dynamic ValidateToken(ClaimsIdentity identity)
        {
            try
            {
                if (identity.Claims.Count() == 0)
                {
                    return new
                    {
                        succes = false,
                        message = "Verify token, this token is not valid",
                        result = ""
                    };
                }

                var id = identity.Claims.FirstOrDefault(x => x.Type == "id").Value;
                var user = _userRepository.GetUser(int.Parse(id));

                return new
                {
                    success = true,
                    message = "succes",
                    result = user.Result
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    succes = false,
                    message = "Catch: " + ex.Message,
                    result = ""
                };
            }
        }
    }
}
