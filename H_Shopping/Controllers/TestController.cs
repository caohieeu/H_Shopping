using Microsoft.AspNetCore.Mvc;
using System.IO.Enumeration;

namespace H_Shopping.Controllers
{
	public class TestController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult FileUpload()
		{
			string filePath = Path.Combine(GlobalConfig.contentRootPath, "wwwroot", "images", "mycuti.jpg");
			var bytes = System.IO.File.ReadAllBytes(filePath);
			return File(bytes, "image/jpg");
		}
        public IActionResult JsonPage()
        {
			return Json(new
			{
				name = "cao hieeu",
				age = 23,
			});
        }
		public IActionResult Info()
		{
			string username = "Caohieeu";
			return View((object)username);
		}
    }
}
