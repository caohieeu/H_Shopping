using H_Shopping.DTO.Response;
using H_Shopping.Models;
using H_Shopping.Services.IService;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace H_Shopping.Controllers
{
    public class ProductController : Controller
	{
		private readonly IProductService _productService;
		private readonly ProductImageService _productImageService;
		public ProductController(IProductService productService,
			ProductImageService productImageService)
		{
			_productService = productService;
			_productImageService = productImageService;
		}
		public async Task<IActionResult> Index()
		{
			var queryParams = Request.Query
				.ToDictionary(p => p.Key, p => p.Value.ToString());

			List<ProductResponse> productResponses = 
				await _productService.GetProductToView(10, queryParams);
			if (productResponses == null)
			{
				productResponses = new List<ProductResponse>();
			}

			return View(productResponses);
		}
		public async Task<IActionResult> Detail(int id)
		{
			ProductResponse productResponse = new ProductResponse();
			if(id != null)
			{
				productResponse = await _productService.FindProductById(id);
			}
			return View(productResponse);
		}
		[Route("getAPI/[controller]/[action]")]
        [Route("getAPI/[controller]/eoi")]
		[Route("cac-san-pham")]
		public IActionResult TestController()
		{
            return Json(
				new
				{
					key1 = 100,
					key2 = new string[] { "a", "b", "c" }
				}
			);
        }
	}
}
