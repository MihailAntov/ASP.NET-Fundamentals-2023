using Library.Data;
using Library.Data.Entities;
using Library.Models.Book;
using Library.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext context;
        public BookService(LibraryDbContext context)
        {
            this.context = context;
        }

        public async Task AddToMyBooks(int bookId, string collectorId)
        {
            var alreadyAdded = await context.IdentityUsersBooks
                .AnyAsync(c => c.CollectorId == collectorId && c.BookId == bookId);

            if (!alreadyAdded)
            {


                await context.IdentityUsersBooks
                    .AddAsync(new IdentityUserBook()
                    {
                        BookId = bookId,
                        CollectorId = collectorId
                    });
                await context.SaveChangesAsync();
            }
        }



        public async Task<IEnumerable<AllBookViewModel>> AllBooksAsync()
        {
            var books = await context.Books
                .Select(b => new AllBookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    ImageUrl = b.ImageUrl,
                    Author = b.Author,
                    Rating = b.Rating,
                    Category = b.Category.Name
                }).ToArrayAsync();

            return books;
        }



        public async Task CreateBookAsync(BookFormViewModel model)
        {
            var newBook = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                Rating = model.Rating,
                CategoryId = model.CategoryId,
                ImageUrl = model.Url

            };
            await context.Books.AddAsync(newBook);
            await context.SaveChangesAsync();

        }

        public async Task<IEnumerable<CategoryListViewModel>> GetAllCategoriesAsync()
        {
            var categories = await context.Categories
                .Select(c => new CategoryListViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToArrayAsync();

            return categories;
        }

        public async Task<AllBookViewModel?> GetBookById(int bookId)
        {
            var book = await context.Books.FindAsync(bookId);
            if (book == null)
            {
                return null;
            }
            var model = new AllBookViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Rating = book.Rating,
                ImageUrl = book.ImageUrl
            };

            return model;
        }

        public async Task<IEnumerable<MyBookViewModel>> MyBooksAsync(string userId)
        {
            var books = await context.IdentityUsersBooks
                .Where(i => i.CollectorId == userId)

                .Select(b => new MyBookViewModel()
                {
                    Id = b.Book.Id,
                    Title = b.Book.Title,
                    ImageUrl = b.Book.ImageUrl,
                    Author = b.Book.Author,
                    Description = b.Book.Description,
                    Category = b.Book.Category.Name
                }).ToArrayAsync();

            return books;
        }

        public async Task RemoveFromMyBooks(int bookId, string collectorId)
        {
            var record = await context.IdentityUsersBooks
                .FirstOrDefaultAsync(c => c.CollectorId == collectorId && c.BookId == bookId);

            if (record != null)
            {
                context.IdentityUsersBooks.Remove(record);
            }

            await context.SaveChangesAsync();
        }
    }
}
