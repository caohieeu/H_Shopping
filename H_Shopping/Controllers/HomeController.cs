using H_Shopping.DTO.Response;
using H_Shopping.Models;
using H_Shopping.Services.IService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace H_Shopping.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        public HomeController(ILogger<HomeController> logger, 
            IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
			var queryParams = Request.Query
				.ToDictionary(p => p.Key, p => p.Value.ToString());
			List<ProductResponse> products = await _productService.GetProductToView(10, queryParams);
            if(products == null)
            {
                products = new List<ProductResponse>();
            }

			return View(products);
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
