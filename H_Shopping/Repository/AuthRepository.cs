using H_Shopping.DAL;
using H_Shopping.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace H_Shopping.Repository
{
	public class AuthRepository : IAuthRepository
	{
		private readonly DataContext _dataContext;
		public AuthRepository(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public async Task<bool> ExistByUsername(string username)
		{
			return await _dataContext.Users
				.Where(p => p.UserName == username)
				.FirstOrDefaultAsync() != null;
		}
	}
}
