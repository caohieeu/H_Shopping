using AutoMapper;
using H_Shopping.DTO.Response;
using H_Shopping.Models;
using H_Shopping.Repository;
using H_Shopping.Repository.IRepository;
using H_Shopping.Services.IService;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace H_Shopping.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ProductImageService _imageService;
        public CategoryService(IProductRepository productRepository,
            IMapper mapper,
            ProductImageService imageService, 
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _imageService = imageService;
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> AddCategory(CategoryModel categoryModel)
        {
            return await _categoryRepository.Add(categoryModel);
        }

        public async Task<IEnumerable<CategoryModel>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<CategoryModel> GetCategory(int categoryId)
        {
            return await _categoryRepository.GetById(categoryId);
        }

        public async Task<List<ProductResponse>> GetProducts(string slug)
        {
            List<ProductModel> listProduct =
                await _productRepository.GetProductsByCategory(slug);
            List<ProductResponse> productResponses = new List<ProductResponse>();
            foreach (ProductModel productModel in listProduct)
            {
                ProductResponse productResponse = _mapper.Map<ProductResponse>(productModel);
                List<ProductImageModel> image =
                    await _imageService.GetImageByProductId(productModel.Id);
                productResponse.images = image;
                productResponses.Add(productResponse);
            }
            return productResponses;
        }

        public async Task<bool> RemoveCategory(int categoryId)
        {
            var categoryDeleted = await _categoryRepository.GetById(categoryId);
            return await _categoryRepository.Remove(categoryDeleted);
        }

        public async Task<bool> UpdateCategory(CategoryModel categoryModel)
        {
            return await _categoryRepository.Update(categoryModel);
        }
    }
}
