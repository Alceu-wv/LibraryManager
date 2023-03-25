using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private IAuthorService _authorService { get; }

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthorsAsync()
        {
            var authors = await _authorService.GetAllAuthorsAsync();

            return Ok(authors);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetAuthorAsync(long id)
        {
            var author = await _authorService.GetAuthorAsync(id);

            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthorAsync(Author author)
        {
            var resp = await _authorService.CreateAuthorAsync(author);

            return Created("Resource created successfully!", resp);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthorAsync(Author author)
        {
            await _authorService.UpdateAuthorAsync(author);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAuthorAsync(long id)
        {
            await _authorService.DeleteAuthorAsync(id);

            return Ok("Resource deleted successfully");
        }
    }
}
