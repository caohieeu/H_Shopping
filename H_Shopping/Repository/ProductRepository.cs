using H_Shopping.DAL;
using H_Shopping.DTO.Response;
using H_Shopping.Models;
using H_Shopping.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace H_Shopping.Repository
{
	public class ProductRepository : Repository<ProductModel>, IProductRepository
	{
		private readonly DataContext _dataContext;
		public ProductRepository(DataContext dataContext):base(dataContext)
		{
			_dataContext = dataContext;
		}	
		public async Task<List<ProductModel>> GetProductsByBrand(string slug)
		{
			List<ProductModel> products = await _dataContext.Products
				.Where(p => p.Brand.Slug == slug)
				.Include(p => p.Brand)
				.Include(p => p.Category)
				.ToListAsync();
			return products;
		}
		public async Task<ProductModel> GetByIdInclude(int id)
		{
			return await _dataContext.Products
				.Where(p => p.Id == id)
				.Include(p => p.Brand)
				.Include(p => p.Category)
				.FirstOrDefaultAsync() ?? new ProductModel();
		}

        public async Task<List<ProductModel>> GetProductsByCategory(string slug)
        {
            List<ProductModel> products = await _dataContext.Products
                .Where(p => p.Category.Slug == slug)
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .ToListAsync();
            return products;
        }

		public async Task<long> QuantityOfProductByBrand(string slug)
		{
			return await _dataContext.Products
				.Where(p => p.Brand.Slug == slug)
				.CountAsync();
		}
	}
}
