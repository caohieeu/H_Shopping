using H_Shopping.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace H_Shopping.Repository.Components
{
    public class BrandsViewComponent : ViewComponent
	{
		private readonly DataContext _context;

		public BrandsViewComponent(DataContext context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var categories = await _context.Brands.ToListAsync();
			return View(categories);
		}
	}
}
