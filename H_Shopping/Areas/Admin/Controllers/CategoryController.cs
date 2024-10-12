using H_Shopping.Models;
using H_Shopping.Services;
using H_Shopping.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace H_Shopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryModel categoryModel)
        {
            if (await _categoryService.AddCategory(categoryModel))
            {
                TempData["AddCategorySuccess"] = "Success";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["AddCategoryError"] = "Failed";
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> Edit(int categoryId)
        {
            var category = await _categoryService.GetCategory(categoryId);
            TempData["Category"] = JsonConvert.SerializeObject(category);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryModel category)
        {
            if (await _categoryService.UpdateCategory(category))
            {
                TempData["StatusUpdateCategory"] = "Success";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["StatusUpdateCategory"] = "Failed";
                return RedirectToAction();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int categoryId)
        {
            if (await _categoryService.RemoveCategory(categoryId))
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Delete category failed";
                return RedirectToAction("Index");
            }
        }
    }
}
