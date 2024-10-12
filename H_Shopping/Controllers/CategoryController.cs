using H_Shopping.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace H_Shopping.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;
		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}
		public async Task<IActionResult> Index(string slug = "")
		{
            var listProductByBrand = await _categoryService.GetProducts(slug);
            return View(listProductByBrand);
        }
	}
}
