using H_Shopping.DTO.Response;
using H_Shopping.Models;

namespace H_Shopping.Repository.IRepository
{
    public interface IProductRepository : IRepository<ProductModel>
    {
        Task<List<ProductModel>> GetProductsByBrand(string slug);
        Task<List<ProductModel>> GetProductsByCategory(string slug);
		Task<long> QuantityOfProductByBrand(string slug);
		Task<ProductModel> GetByIdInclude(int id);

	}
}
