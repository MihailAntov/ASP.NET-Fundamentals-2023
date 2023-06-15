using CarShop.ViewModels.Car;

namespace CarShop.Services.Contracts
{
    public interface ICarService
    {
        public Task<IEnumerable<CarListViewModel>> GetAllCarsAsync();
        Task AddCarAsync(CarFormViewModel model, string ownerId);
    }
}
