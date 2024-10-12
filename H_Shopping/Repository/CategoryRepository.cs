using H_Shopping.DAL;
using H_Shopping.Models;
using H_Shopping.Repository.IRepository;
using H_Shopping.Repository;

public class CategoryRepository : Repository<CategoryModel>, ICategoryRepository
{
    public CategoryRepository(DataContext dataContext) : base(dataContext)
    {
    }
}