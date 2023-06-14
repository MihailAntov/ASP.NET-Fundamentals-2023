using Microsoft.EntityFrameworkCore;
using Musaca.Data;
using Musaca.Data.Entities;
using Musaca.Services.Contracts;
using Musaca.ViewModels.Product;

namespace Musaca.Services
{
    public class ProductService : IProductService
    {
        private readonly MusacaDbContext context;
        public ProductService(MusacaDbContext context)
        {
            this.context = context;
        }

        public async Task CreateProductAsync(ProductFormViewModel model)
        {
            Product product = new Product()
            {
                Name = model.Name,
                Picture = model.Picture,
                Price = model.Price,
                Barcode = model.Barcode
            };
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductListViewModel>> GetAllProductsAsync()
        {
            var result = await context.Products
                .Select(p => new ProductListViewModel()
                {
                    Name=p.Name,
                    Barcode = p.Barcode,
                    Picture = p.Picture,
                    Price =p.Price

                }).ToArrayAsync();

            return result;
        }

        public async Task<ProductViewModel?> GetProductAsync(string barcode)
        {
            var result = await context.Products
                .Select(p=> new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Barcode = p.Barcode
                })
                .FirstOrDefaultAsync(p => p.Barcode == barcode);
            return result;
            
        }
    }
}
