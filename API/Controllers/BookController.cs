using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private IBookService _bookService { get; }

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            var books = await _bookService.GetAllBooksAsync();

            return Ok(books);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetBookAsync(long id)
        {
            var book = await _bookService.GetBookAsync(id);

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookAsync(Book book)
        {
            var resp = await _bookService.CreateBookAsync(book);

            return Created("Resource created successfully!", resp);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBookAsync(Book book)
        {
            await _bookService.UpdateBookAsync(book);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBookAsync(long id)
        {
            await _bookService.DeleteBookAsync(id);

            return Ok("Resource deleted successfully");
        }
    }
}
