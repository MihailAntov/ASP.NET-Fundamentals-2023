using Microsoft.EntityFrameworkCore;
using Musaca.Data;
using Musaca.Data.Entities;
using Musaca.Services.Contracts;
using Musaca.ViewModels.Order;

namespace Musaca.Services
{
    public class OrderService : IOrderService
    {
        private readonly MusacaDbContext context;
        
        public OrderService(MusacaDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Cashout(string id)
        {
            var activeOrders = await context
                .Orders
                .Where(o => o.Status == Common.Enums.Status.Active)
                .ToArrayAsync();

            Receipt receipt = new Receipt()
            {
                CashierId = id,
                Orders = activeOrders,
                IssuedOn = DateTime.UtcNow
            };
            await context.Receipts.AddAsync(receipt);

            foreach(var order in activeOrders)
            {
                order.Status = Common.Enums.Status.Completed;
            }

            await context.SaveChangesAsync();
            return receipt.Id.ToString();

        }

        public async Task CreateOrderAsync(OrderFormViewModel model, string cashierId)
        {
            Order order = new Order()
            {
                CashierId = cashierId,
                ProductId = model.ProductId,
                Quantity = model.Quantity,
                Status = Common.Enums.Status.Active
            };

            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<OrderDisplayViewModel>> GetActiveOrdersAsync(string id)
        {
            var activeOrders = await context.Orders
                .Where(o => o.Status == Common.Enums.Status.Active && o.Cashier.Id == id)
                .Select(o => new OrderDisplayViewModel()
                {
                    Name = o.Product.Name,
                    Total = o.Product.Price,
                    Quantity = o.Quantity
                }).ToArrayAsync();

            return activeOrders;
        }
    }
}
