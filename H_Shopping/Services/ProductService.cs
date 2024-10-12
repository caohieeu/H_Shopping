using AutoMapper;
using H_Shopping.DAL;
using H_Shopping.DTO.Response;
using H_Shopping.Models;
using H_Shopping.Repository.IRepository;
using H_Shopping.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace H_Shopping.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;
        private readonly ProductImageService _imageService;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(DataContext dataContext,
            ProductImageService imageService,
			IProductRepository productRepository,
            IMapper mapper)
        {
            _dataContext = dataContext;
            _imageService = imageService;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public List<ProductModel> GetAll()
        {
            return _dataContext.Products.ToList();
        }
        public async Task<List<ProductImageModel>> GetImagesOfProduct(int id)
        {
			List<ProductImageModel> productImageModels =
					await _imageService.GetImageByProductId(id);
            if(productImageModels == null)
            {
                productImageModels = new List<ProductImageModel>();
            }
            return productImageModels;
		}
        public async Task<ProductResponse> FindProductById(int id)
        {
            ProductModel product = await _productRepository.GetByIdInclude(id);
            if (product == null)
            {
                product = new ProductModel();
            }
            ProductResponse productResponse = _mapper.Map<ProductResponse>(product);
			List<ProductImageModel> productImageModels =
					await _imageService.GetImageByProductId(id);
			productResponse.images = productImageModels;
            return productResponse;

		}
        public async Task<List<ProductResponse>> GetProductToView(int quantity, Dictionary<string, string> queryParams)
		{
			List<ProductResponse> productResponses = new List<ProductResponse>();
            var query = _dataContext.Set<ProductModel>().AsQueryable();

			if (queryParams.TryGetValue("name", out var productName))
			{
				query = query.Where(p => p.Name.Contains(productName));
			}
			if (queryParams.TryGetValue("brand", out var productBrand))
			{
				query = query.Where(p => p.Name.Contains(productBrand));
			}
			if (queryParams.TryGetValue("priceFrom", out var priceFromStr) && 
                decimal.TryParse(priceFromStr, out var priceFrom))
			{
                query = query.Where(p => p.Price <= priceFrom);
			}
			if (queryParams.TryGetValue("priceTo", out var priceToStr) &&
                decimal.TryParse(priceToStr, out var priceTo))
			{
                query = query.Where(p => p.Price >= priceTo);
			}
			if (queryParams.TryGetValue("id", out var productIdStr) &&
                int.TryParse(productIdStr, out var productId))
            {
                query = query.Where(p => p.Id == productId);
            }
            var products = query
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .ToList();

			foreach (ProductModel item in products)
			{
				ProductResponse productResponse = _mapper.Map<ProductResponse>(item);
				List<ProductImageModel> productImageModels =
					await _imageService.GetImageByProductId(item.Id);
				productResponse.images = productImageModels;

				productResponses.Add(productResponse);
			}

			return productResponses;
		}
	}
}
