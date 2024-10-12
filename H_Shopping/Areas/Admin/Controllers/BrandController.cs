using H_Shopping.Models;
using H_Shopping.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace H_Shopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _brandService.GetAll());
        }
        public async Task<IActionResult> Edit(int brandId)
        {
            var brand = await _brandService.GetBrand(brandId);
            TempData["Brand"] = JsonConvert.SerializeObject(brand);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BrandModel brand)
        {
            if(await _brandService.UpdateBrand(brand))
            {
                TempData["StatusUpdateBrand"] = "Success";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["StatusUpdateBrand"] = "Failed";
                return RedirectToAction();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(BrandModel brandModel)
        {
            if(await _brandService.AddBrand(brandModel))
            {
                TempData["AddBrandSuccess"] = "Success";
                return RedirectToAction("Index");   
            }
            else
            {
                TempData["AddBrandError"] = "Failed";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int branId)
        {
            if (await _brandService.RemoveBrand(branId))
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Delete brand failed";
                return RedirectToAction("Index");
            }
        }
    }
}
