using H_Shopping.DTO.Response;
using H_Shopping.Models;
//using System.Data.Entity;
using System.Linq;
namespace H_Shopping.Services.IService
{
    public interface IProductService
    {
        List<ProductModel> GetAll();
        Task<ProductResponse> FindProductById(int id);
		Task<List<ProductResponse>> GetProductToView(int quantity, Dictionary<string, string> queryParams);
    }
}
