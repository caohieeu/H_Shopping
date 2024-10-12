using H_Shopping.DAL;
using H_Shopping.Models;
using Microsoft.EntityFrameworkCore;

namespace H_Shopping.Services.IService
{
    public class ProductImageService
    {
        private readonly DataContext _dataContext;
        public ProductImageService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<ProductImageModel>> GetImageByProductId(int id)
        {
            return await _dataContext.ProductImages
                .Where(x => x.ProductId == id)
                .ToListAsync();
        }
    }
}
