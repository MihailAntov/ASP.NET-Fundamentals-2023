using CarShop.Data;
using CarShop.Data.Entities;
using CarShop.Services.Contracts;
using CarShop.ViewModels.Car;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Services
{
    public class CarService : ICarService
    {
        private readonly CarShopDbContext context;
        public CarService(CarShopDbContext context)
        {
            this.context = context;
        }

        public async Task AddCarAsync(CarFormViewModel model, string ownerId)
        {
            Car car = new Car()
            {
                OwnerId = ownerId,
                Name = model.Name,
                PictureUrl = model.ImageUrl,
                PlateNumber = model.PlateNumber,
                Year = model.Year
            };

            await context.Cars.AddAsync(car);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CarListViewModel>> GetAllCarsAsync()
        {
            var cars = await context.Cars
                .Select(c => new CarListViewModel()
                {
                    Id = c.Id.ToString(),
                    PlateNumber = c.PlateNumber,
                    ImageUrl = c.PictureUrl,
                    FixedIssues = c.Issues.Where(i=> i.IsFixed == true).Count(),
                    RemainingIssues = c.Issues.Where(i=>i.IsFixed == false).Count(),
                    ModelAndYear = $"{c.Year} {c.Name}"

                }).ToArrayAsync();

            return cars;
        }
    }
}
