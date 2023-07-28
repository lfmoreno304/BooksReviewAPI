using BooksReviewAPI.Services;
using Data;
using DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Security.Claims;

namespace BooksReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IUserService _userService;
        public ReviewController(IReviewRepository reviewRepository, IUserService userService)
        {
            _reviewRepository = reviewRepository;
            _userService = userService; 
        }
        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {

            return Ok(await _reviewRepository.GetReviews());
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateReview([FromBody] Review review)
        {
         
            var indentity = HttpContext.User.Identity as ClaimsIdentity;
            var rToken = _userService.ValidateToken(indentity);

            if (!rToken.success) return rToken;

            var user = rToken.result;

            review.User_id = user.User_id;

            if (review == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _reviewRepository.InsertReview(review);

            return Created("created", created);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetDetails(int id)
        {
            return Ok(await _reviewRepository.GetDetails(id));
        }
        [HttpGet("book_id")]
        public async Task<IActionResult> GetBooksReviews(int id)
        {
            return Ok(await _reviewRepository.GetBooksReviews(id));
        }
        [HttpGet("user_id")]
        public async Task<IActionResult> GetUsersReviews(int id)
        {
            return Ok(await _reviewRepository.GetUsersReviews(id));
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateReview([FromBody] Review review)
        {
            var indentity = HttpContext.User.Identity as ClaimsIdentity;
            var rToken = _userService.ValidateToken(indentity);

            if (!rToken.success) return rToken;

            var user = rToken.result;

            review.User_id = user.User_id;

            if (review == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _reviewRepository.UpdateReview(review);

            return NoContent();
        }
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var indentity = HttpContext.User.Identity as ClaimsIdentity;
            var rToken = _userService.ValidateToken(indentity);

            if (!rToken.success) return rToken;
            var user = rToken.result;

            await _reviewRepository.DeleteReview(new Review { Review_id = id },user.User_id);

            return NoContent();

        }
    }
}
