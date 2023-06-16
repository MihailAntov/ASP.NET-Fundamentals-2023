using CarShop.Services.Contracts;
using CarShop.ViewModels.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarShop.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        private readonly ICarService carService;
        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }

        public async Task<IActionResult> All()
        {
            var model = await carService.GetAllCarsAsync();
            return View(model);
        }

        [Authorize(Roles = "Customer")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> Add(CarFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await carService.AddCarAsync(model, userId);
            return RedirectToAction("All", "Cars");
        }
    }
}
