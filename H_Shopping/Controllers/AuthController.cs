using AutoMapper;
using H_Shopping.DTO.Request;
using H_Shopping.Models;
using H_Shopping.Services.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace H_Shopping.Controllers
{
	public class AuthController : Controller
	{
		private readonly IAuthService _authService;
		private readonly UserManager<AppUser> _userManager;
		private readonly IMapper _mapper;
		public AuthController(IAuthService authService, 
			UserManager<AppUser> userManager,
			IMapper mapper)
		{
			_authService = authService;
			_userManager = userManager;
			_mapper = mapper;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterRequest registerRequest)
		{
			if(ModelState.IsValid)
			{
				AppUser user = _mapper.Map<AppUser>(registerRequest);
				var result = await _userManager.CreateAsync(user, registerRequest.Password);

				if (result.Succeeded)
				{
					var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
					code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

					//var callBackUrl = Url.Page(
					//		"/Auth/Success",
					//		pageHandler: null,
					//		values: new {}
					//	)

					Console.WriteLine(code);
					return RedirectToAction("Success");
				}
				else
				{
					ViewData["message"] = "Username is already exist";
				}
			}
			return View();
		}
		public IActionResult Login()
		{
			return View();
		}
		public IActionResult Success()
		{
			return View();
		}
	}
}
