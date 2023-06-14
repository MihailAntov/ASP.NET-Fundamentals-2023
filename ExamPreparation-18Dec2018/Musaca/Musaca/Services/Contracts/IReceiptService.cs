using Musaca.ViewModels.Receipt;

namespace Musaca.Services.Contracts
{
    public interface IReceiptService
    {
        public Task<ICollection<ReceiptViewModel>> GetMyReceiptsAsync(string id);
        public Task<ICollection<ReceiptViewModel>> GetAllReceiptsAsync();

        public Task<ReceiptViewModel?> Details(string id);
    }
}
