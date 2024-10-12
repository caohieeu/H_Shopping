using H_Shopping.DTO.Response;
using H_Shopping.Models;

namespace H_Shopping.Services.IService
{
	public interface IBrandService
	{
		Task<IEnumerable<BrandModel>> GetAll();
        Task<BrandModel> GetBrand(int brandId);
        Task<bool> AddBrand(BrandModel brandModel);
        Task<bool> RemoveBrand(int brandId);
        Task<List<ProductResponse>> GetProducts(string slug);
		Task<long> ProductQuantity(string slug);
        Task<bool> UpdateBrand(BrandModel brand);
    }
}
