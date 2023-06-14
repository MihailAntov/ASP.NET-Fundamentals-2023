using Microsoft.AspNetCore.Mvc;
using Musaca.Data.Entities;
using Musaca.Services.Contracts;
using Musaca.ViewModels.Order;
using Musaca.ViewModels.Product;
using System.Security.Claims;

namespace Musaca.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrderService orderService;
        public ProductsController(IProductService productService, IOrderService orderService)
        {
            this.productService = productService;
            this.orderService = orderService;
        }
        [HttpPost]
        public async Task<IActionResult> Order(OrderFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            var product = await productService.GetProductAsync(model.Barcode);
            if(product == null)
            {
                return RedirectToAction("Index", "Home");      
            }

            string cashierId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            
            model.ProductId = product.Id;
            await orderService.CreateOrderAsync(model, cashierId);

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Cashout()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            string receiptId = await orderService.Cashout(userId);
            return RedirectToAction("Index", "Home",receiptId);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            
            await productService.CreateProductAsync(model);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> All()
        {
            var model = await productService.GetAllProductsAsync();
            return View(model);
        }
    }
}
