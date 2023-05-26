using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Text_Splitter.Models;
using Text_Splitter.Models.Home;

namespace Text_Splitter.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index(TextViewModel model)
		{
			return View(model);
		}
		[HttpPost]
		public IActionResult Split(TextViewModel model)
		{
			if(!ModelState.IsValid)
			{
				return RedirectToAction("Index", model);
			}
			
			var splitTextArray = model.Text
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.ToArray();
			model.SplitText = String.Join(Environment.NewLine, splitTextArray);
			return RedirectToAction("Index", model);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}