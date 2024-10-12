using H_Shopping.DTO.Response;
using H_Shopping.Services;
using H_Shopping.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace H_Shopping.Controllers
{
	public class BrandController : Controller
	{
		private readonly IBrandService _brandService;
		public BrandController(IBrandService brandService)
		{
			_brandService = brandService;
		}
		public async Task<IActionResult> Index(string slug = "")
		{
			var listProductByBrand = await _brandService.GetProducts(slug);
			return View(listProductByBrand);
		}
	}
}
