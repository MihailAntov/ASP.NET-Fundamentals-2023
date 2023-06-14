using Musaca.ViewModels.Order;

namespace Musaca.Services.Contracts
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderDisplayViewModel>> GetActiveOrdersAsync(string id);
        public Task CreateOrderAsync(OrderFormViewModel model, string cashierId);

        public Task<string> Cashout(string id);
    }
}
