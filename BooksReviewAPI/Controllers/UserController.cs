using BooksReviewAPI.Services;
using Data;
using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Model;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BooksReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        
        public UserController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            
        }
        [HttpPost]
        [Route("login")]
        public async Task<dynamic> Login([FromBody] Object optData)
        {
            var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());

            string email = data.email.ToString();
            string password = data.password.ToString();
            var user = await _userRepository.GetUserByEmailAndPassword(email, password);

            if (user == null)
            {
                return new
                {
                    success = false,
                    message = "Credenciales incorrectas",
                    result = ""
                };
            }

            Jwt jwt = new Jwt(_configuration["Key"], _configuration["Issuer"], _configuration["Audience"], _configuration["Subject"]);
          
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub,jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                new Claim("id", user.User_id.ToString()),
                new Claim("email", user.email),
                new Claim("password", user.password)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    jwt.Issuer,
                    jwt.Audience,
                    claims,
                    expires: DateTime.Now.AddHours(36),
                    signingCredentials: signIn
                );
            return new
            {
                success = true,
                message = "succes",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetUser(int id)
        {
            return Ok(await _userRepository.GetUser(id));
        }
        [HttpPost]
        public async Task<IActionResult> InsertUser([FromBody] Users user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _userRepository.InsertUser(user);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] Users user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _userRepository.UpdateUser(user);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {

            await _userRepository.DeleteUser(new Users { User_id = id });

            return NoContent();

        }
    }
}
