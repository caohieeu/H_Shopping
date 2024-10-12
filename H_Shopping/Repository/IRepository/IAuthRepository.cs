namespace H_Shopping.Repository.IRepository
{
	public interface IAuthRepository
	{
		Task<bool> ExistByUsername(string username);
	}
}
