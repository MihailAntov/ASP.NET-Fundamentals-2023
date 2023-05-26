
using ASP.NET_Core_Introduction.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ASP.NET_Core_Introduction.Controllers
{
    public class ProductController : Controller
    {
        private ICollection<ProductViewModel> products = new List<ProductViewModel>()
        {
            new ProductViewModel()
            {
                Id = 1,
                Name = "Cheese",
                Price = 7.0M
            },
            new ProductViewModel()
            {
                Id = 2,
                Name = "Ham",
                Price = 5.50M
            },
            new ProductViewModel()
            {
                Id = 3,
                Name = "Bread",
                Price = 1.50M
            }
        };


        
        public IActionResult All(string keyword)
        {
            if(keyword != null)
            {
                var foundProducts = products.Where(p => p.Name.ToLower().Contains(keyword.ToLower())).ToList();
                return View(foundProducts);
            }
            return View(products);
        }

        public IActionResult ById(int id)
        {
            ProductViewModel product = products.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            return Json(products, options);
        }

        public IActionResult AllAsText()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var product in products)
            {
                sb.AppendLine($"#{product.Id} : {product.Name} - {product.Price}");
                sb.AppendLine();
            }

            return Content(sb.ToString());
        }

        public IActionResult AllAsTextFile()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var product in products)
            {
                sb.AppendLine($"#{product.Id} : {product.Name} - {product.Price}");
                sb.AppendLine();
            }

            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");
            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
        }
    }
}
