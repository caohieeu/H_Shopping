using H_Shopping.DTO.Request;

namespace H_Shopping.Services.IService
{
	public interface IAuthService
	{
		Task<bool> Register(RegisterRequest registerRequest);
	}
}
