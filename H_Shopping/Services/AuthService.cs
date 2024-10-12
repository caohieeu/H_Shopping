using AutoMapper;
using H_Shopping.DAL;
using H_Shopping.DTO.Request;
using H_Shopping.Models;
using H_Shopping.Repository.IRepository;
using H_Shopping.Services.IService;

namespace H_Shopping.Services
{
	public class AuthService : IAuthService
	{
		private readonly IAuthRepository _authRepository;
		private readonly IMapper _mapper;
		private readonly DataContext _dataContext;
		public AuthService(IAuthRepository authRepository,
			IMapper mapper, DataContext dataContext)
		{
			_authRepository = authRepository;
			_mapper = mapper;
			_dataContext = dataContext;
		}
		public async Task<bool> Register(RegisterRequest registerRequest)
		{
			bool result = false;
			if(!await _authRepository.ExistByUsername(registerRequest.UserName))
			{
				UserModel user = _mapper.Map<UserModel>(registerRequest);
				user.Password = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password);
				user.RoleId = Util.Roles.User;
				//_dataContext.Users.Add(user);
				if(await _dataContext.SaveChangesAsync() > 0)
				{
					result = true;
				}
			}
			return result;
		}
	}
}
