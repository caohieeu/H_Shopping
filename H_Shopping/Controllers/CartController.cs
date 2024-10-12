using Microsoft.AspNetCore.Mvc;

namespace H_Shopping.Controllers
{
	public class CartController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Checkout()
		{
			return View("~/Views/Checkout/Index.cshtml");
		}
	}
}
