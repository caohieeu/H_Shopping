using System.Linq.Expressions;

namespace H_Shopping.Repository.IRepository
{
	public interface IRepository<T> where T : class
	{
		Task<T> GetById(int id);
		Task<IEnumerable<T>> GetAll();
		Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
		Task<bool> Add(T entity);
		Task<bool> AddRange(IEnumerable<T> entities);
		Task<bool> Remove(T entity);
		Task<bool> RemoveRange(IEnumerable<T> entities);
		Task<bool> Update(T entity);

    }
}
