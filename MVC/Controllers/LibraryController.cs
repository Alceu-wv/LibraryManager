using Domain.Interfaces.Services;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class LibraryController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        public LibraryController(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        [HttpGet]
        public ViewResult CreateAuthorPage() => View();


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // obter todos os autores
            var authors = await _authorService.GetAllAuthorsAsync();
            var authorViewModels = authors.Select(a => new AuthorViewModel
            {
                Id = a.Id,
                FullName = $"{a.FirstName} {a.LastName}"
            }).ToList();

            // criar uma nova viewModel para a view
            var viewModel = new BookViewModel
            {
                Authors = authorViewModels
            };

            return View(viewModel);
        }


        /*
        [HttpPost]
        public IActionResult Create(BookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // criar novo livro com autor
                var book = new Book
                {
                    Title = viewModel.Title,
                    ISBN = viewModel.ISBN,
                    ReleaseYear = viewModel.ReleaseYear,
                    AuthorId = new List<Author> { _authorService.GetById(viewModel.AuthorId) }
                };

                // adicionar novo livro ao contexto e salvar
                _bookService.Create(book);

                // redirecionar para a página inicial
                return RedirectToAction("Index");
            }

            // se a ModelState não for válida, retornar a mesma view com os dados do viewModel
            viewModel.Authors = _authorService.GetAll().Select(a => new AuthorViewModel
            {
                Id = a.Id,
                FullName = $"{a.FirstName} {a.LastName}"
            }).ToList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                _authorService.Add(author);
                BookViewModel viewModel = new();
                viewModel.Authors = _authorService.GetAll().Select(a => new AuthorViewModel
                {
                    Id = a.Id,
                    FullName = $"{a.FirstName} {a.LastName}"
                }).ToList();
                return View("Create", viewModel);
            }

            return BadRequest();
        }
        */
    }
}
