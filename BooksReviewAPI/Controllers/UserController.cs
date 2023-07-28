using Data;
using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
