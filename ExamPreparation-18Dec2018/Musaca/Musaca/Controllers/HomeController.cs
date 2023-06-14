using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Musaca.ViewModels;
using Musaca.Services;
using Musaca.Services.Contracts;
using System.Diagnostics;
using System.Security.Claims;
using Musaca.ViewModels.Order;

namespace Musaca.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IReceiptService _receiptService;
        private readonly IOrderService _orderService;

        public HomeController( IReceiptService receiptService, IOrderService orderService)
        {
            _receiptService = receiptService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new OrderFormViewModel();
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.Orders = await _orderService.GetActiveOrdersAsync(userId);
            model.Sum = model.Orders.Sum(o => o.Total);
            return View(model);
        }
        
        public async Task<IActionResult> Profile()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await _receiptService.GetMyReceiptsAsync(userId);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}