using H_Shopping.Models;

namespace H_Shopping.Repository.IRepository
{
	public interface IBrandRepository : IRepository<BrandModel>
	{
		Task<bool> Update(BrandModel brandModel);
	}
}
