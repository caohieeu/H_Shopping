using H_Shopping.DTO.Response;
using H_Shopping.Models;

namespace H_Shopping.Services.IService
{
	public interface ICategoryService
    {
        Task<List<ProductResponse>> GetProducts(string slug);
        Task<IEnumerable<CategoryModel>> GetAll();
        Task<CategoryModel> GetCategory(int categoryId);
        Task<bool> AddCategory(CategoryModel categoryModel);
        Task<bool> RemoveCategory(int categoryId);
        Task<bool> UpdateCategory(CategoryModel categoryModel);
    }
}
