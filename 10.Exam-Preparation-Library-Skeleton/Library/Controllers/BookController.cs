using Library.Models.Book;
using Library.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService;
		public BookController(IBookService bookService)
		{
            this.bookService = bookService;
		}
        public async Task<IActionResult> All()
        {
            var allBooks = await bookService.AllBooksAsync();

			return View(allBooks);
        }

        public async Task<IActionResult> Mine()
        {
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var myBooks = await bookService.MyBooksAsync(currentUserId);
            return View(myBooks);
        }

		[HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await bookService.GetAllCategoriesAsync();
            BookFormViewModel model = new BookFormViewModel()
            {
                Categories = categories
            };

            return View(model);
        }
		[HttpPost]
        public async Task<IActionResult> Add(BookFormViewModel model)
        {
			if (!ModelState.IsValid)
			{
                return View(model);
			}

            await bookService.CreateBookAsync(model);
            return RedirectToAction("All", "Book");
        }

        public async Task<IActionResult> AddToCollection(int id)
        {
            var book = await bookService.GetBookById(id);
            if(book == null)
			{
                return RedirectToAction("All", "Book");
			}
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await bookService.AddToMyBooks(id, userId);
            return RedirectToAction("All", "Book");

        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var book = await bookService.GetBookById(id);
            if (book == null)
            {
                return RedirectToAction("All", "Book");
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await bookService.RemoveFromMyBooks(id, userId);
            return RedirectToAction("Mine", "Book");
        }
    }
}
