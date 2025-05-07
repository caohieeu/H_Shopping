using H_Shopping.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace H_Shopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [Route("{area}/{controller}/")]
        public IActionResult Index()
        {
            var listProduct = productService.GetAll();

            return View(listProduct);
        }
    }
}
