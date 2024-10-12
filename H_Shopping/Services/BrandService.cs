using AutoMapper;
using H_Shopping.DTO.Response;
using H_Shopping.Models;
using H_Shopping.Repository;
using H_Shopping.Repository.IRepository;
using H_Shopping.Services.IService;

namespace H_Shopping.Services
{
	public class BrandService : IBrandService
	{
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;
		private readonly ProductImageService _imageService;
		private readonly IBrandRepository _brandRepository;
		public BrandService(
			IProductRepository productRepository, 
			IMapper mapper,
			ProductImageService imageService,
            IBrandRepository brandRepository)
		{
			_productRepository = productRepository;
			_mapper = mapper;
			_imageService = imageService;
			_brandRepository = brandRepository;
		}

        public async Task<IEnumerable<BrandModel>> GetAll()
        {
            return await _brandRepository.GetAll();
        }
        public async Task<BrandModel> GetBrand(int brandId)
        {
            return await _brandRepository.GetById(brandId);
        }
        public async Task<List<ProductResponse>> GetProducts(string slug)
		{
			List<ProductModel> listProduct = 
				await _productRepository.GetProductsByBrand(slug);
			List<ProductResponse> productResponses = new List<ProductResponse>();
			foreach(ProductModel productModel in listProduct)
			{
				ProductResponse productResponse = _mapper.Map<ProductResponse>(productModel);
				List<ProductImageModel> image =
					await _imageService.GetImageByProductId(productModel.Id);
				productResponse.images = image;
				productResponses.Add(productResponse);
			}
			return productResponses;
		}
		public async Task<long> ProductQuantity(string slug)
		{
			return await _productRepository.QuantityOfProductByBrand(slug);
		}
		public async Task<bool> AddBrand(BrandModel brandModel)
		{
			return await _brandRepository.Add(brandModel);
		}
        public async Task<bool> RemoveBrand(int brandId)
        {
			var brandDeleted = await _brandRepository.GetById(brandId);
            return await _brandRepository.Remove(brandDeleted);
        }
		public async Task<bool> UpdateBrand(BrandModel brand)
		{
			return await _brandRepository.Update(brand);
		}
    }
}
