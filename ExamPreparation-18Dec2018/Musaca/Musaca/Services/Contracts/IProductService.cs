using Musaca.Data.Entities;
using Musaca.ViewModels.Product;

namespace Musaca.Services.Contracts
{
    public interface IProductService
    {
        Task<ProductViewModel?> GetProductAsync(string barcode);
        Task CreateProductAsync(ProductFormViewModel model);

        Task<IEnumerable<ProductListViewModel>> GetAllProductsAsync();
    }
}
