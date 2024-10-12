using AutoMapper;
using H_Shopping.DAL;
using H_Shopping.Models;
using H_Shopping.Repository.IRepository;

namespace H_Shopping.Repository
{
    public class BrandRepository : Repository<BrandModel>, IBrandRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public BrandRepository(DataContext dataContext, 
            IMapper mapper):base(dataContext)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<bool> Update(BrandModel brandModel)
        {
            try
            {
                var brand = _dataContext.Brands
                .Where(x => x.Id == brandModel.Id)
                .FirstOrDefault();
                if (brand == null)
                {
                    brand = new BrandModel();
                }
                brand.Id = brandModel.Id;
                brand.Name = brandModel.Name;
                brand.Status = brandModel.Status;
                brand.Slug = brandModel.Slug;
                brand.Description = brandModel.Description;

                await _dataContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
