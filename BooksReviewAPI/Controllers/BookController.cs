using Data;
using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetBooks() {

            return Ok(await _bookRepository.GetBooks());
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetDetails(int id) {
            return Ok(await _bookRepository.GetDetails(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Books book) {
            if (book == null) {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _bookRepository.InsertBook(book);

            return Created("created",created); 
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] Books book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             await _bookRepository.UpdateBook(book);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int id) {

            await _bookRepository.DeleteBook(new Books { Book_id = id });

            return NoContent();
        
        }
    }
}
