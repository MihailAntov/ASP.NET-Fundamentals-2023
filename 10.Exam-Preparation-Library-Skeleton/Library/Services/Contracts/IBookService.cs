using Library.Models.Book;

namespace Library.Services.Contracts
{
    public interface IBookService
    {
        public Task<IEnumerable<AllBookViewModel>> AllBooksAsync();

        public Task<IEnumerable<MyBookViewModel>> MyBooksAsync(string userId);

        public Task<IEnumerable<CategoryListViewModel>> GetAllCategoriesAsync();

        public Task CreateBookAsync(BookFormViewModel model);

        public Task AddToMyBooks(int bookId, string collectorId);

        public Task RemoveFromMyBooks(int bookId, string collectorId);

        public Task<AllBookViewModel?> GetBookById(int bookId);

        
    }
}
