using H_Shopping.DAL;
using H_Shopping.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

//using System.Data.Entity;
using System.Linq.Expressions;

namespace H_Shopping.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly DataContext _dataContext;
		public Repository(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public async Task<bool> Add(T entity)
		{
			try
			{
                var result = await _dataContext.Set<T>().AddAsync(entity);
                await _dataContext.SaveChangesAsync();
				return true;
            }
			catch
			{
				return false;
			}
		}
		public async Task<bool> AddRange(IEnumerable<T> entities)
		{
            try
			{
                await _dataContext.Set<T>().AddRangeAsync(entities);
                await _dataContext.SaveChangesAsync();
				return true;
            }
			catch
			{
				return false;
			}
        }

		public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
		{
			return await _dataContext.Set<T>().Where(expression).ToListAsync();
		}

		public async Task<IEnumerable<T>> GetAll()
		{
			return await _dataContext.Set<T>().ToListAsync();
		}

		public async Task<T> GetById(int id)
		{
			return await _dataContext.Set<T>().FindAsync(id);
		}

		public async Task<bool> Remove(T entity)
		{
			try
			{
                var result = _dataContext.Set<T>().Remove(entity);
                await _dataContext.SaveChangesAsync();
				return true;
            }
			catch
			{
				return false;
			}
		}

		public async Task<bool> RemoveRange(IEnumerable<T> entities)
		{
			try
			{
                _dataContext.Set<T>().RemoveRange(entities);
                await _dataContext.SaveChangesAsync();
				return true;
            }
			catch
			{
				return false;
			}
		}
        public async Task<bool> Update(T entity)
        {
            try
            {
                _dataContext.Set<T>().Attach(entity);
				_dataContext.Entry(entity).State = EntityState.Modified;
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
