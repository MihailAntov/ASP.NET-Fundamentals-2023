using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Musaca.Services.Contracts;
using System.Security.Claims;

namespace Musaca.Controllers
{
    [Authorize]
    public class ReceiptsController : Controller
    {
        private readonly IReceiptService receiptService;
        public ReceiptsController(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> All()
        {
            var model = await receiptService.GetAllReceiptsAsync();
            return View(model);
        }

        public async Task<IActionResult> Details(string id)
        {
            var model = await receiptService.Details(id);
            if(model == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (!User.IsInRole("Admin") && model.CashierId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}
