using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Musaca.Data;
using Musaca.Services.Contracts;
using Musaca.ViewModels.Order;
using Musaca.ViewModels.Receipt;

namespace Musaca.Services
{
    [Authorize]
    public class ReceiptService : IReceiptService
    {
        private readonly MusacaDbContext context;
        public ReceiptService(MusacaDbContext context)
        {
            this.context = context;
        }

        public async Task<ReceiptViewModel?> Details(string id)
        {
            var receipt = await context.Receipts
                .Where(r=> r.Id.ToString() == id)
                .Select(r=> new ReceiptViewModel()
                {
                    Id = id,
                    Total = r.Orders
                    .Select(o => o.Product.Price * o.Quantity).Sum(),
                    Cashier = r.Cashier.UserName,
                    CashierId = r.CashierId,
                    IssuedOn = r.IssuedOn.ToString(),
                    Orders = r.Orders.Select(o => new OrderDisplayViewModel()
                    {
                        Name = o.Product.Name,
                        Quantity = o.Quantity,
                        Total = o.Product.Price
                    })
                })
                .FirstOrDefaultAsync();

            

            

            return receipt;

        }

        [Authorize(Roles = "Admin")]
        public async Task<ICollection<ReceiptViewModel>> GetAllReceiptsAsync()
        {
            var receipts = await context.Receipts
                .Select(r => new ReceiptViewModel()
                {
                    Id = r.Id.ToString(),
                    Total = r.Orders
                    .Select(o => o.Product.Price * o.Quantity).Sum(),
                    Cashier = r.Cashier.UserName,
                    IssuedOn = r.IssuedOn.ToString(),
                }).ToArrayAsync();

            return receipts;
        }

        public async Task<ICollection<ReceiptViewModel>> GetMyReceiptsAsync(string id)
        {
            var receipts = await context.Receipts
                .Where(r=> r.Cashier.Id == id)
                .Select(r => new ReceiptViewModel()
                {
                    Id = r.Id.ToString(),
                    Total = r.Orders
                    .Select(o=> o.Product.Price * o.Quantity).Sum(),
                    Cashier = r.Cashier.UserName,
                    IssuedOn = r.IssuedOn.ToString(),
                    //Orders = r.Orders.Select(o=> new OrderDisplayViewModel()
                    //{
                    //    Name = o.Product.Name,
                    //    Quantity = o.Quantity,
                    //    Total = o.Product.Price
                    //})
                }).ToArrayAsync();

            return receipts;
        }
    }
}
