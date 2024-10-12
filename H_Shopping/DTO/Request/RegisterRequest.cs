using H_Shopping.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace H_Shopping.DTO.Request
{
	public class RegisterRequest
	{
		[Required(ErrorMessage = "Username is required")]
		[MinLength(6, ErrorMessage = "Username must be at least 6 characters")]
		public string UserName { get; set; }
		[Required(ErrorMessage = "Password is required")]
		[MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
		public string Password { get; set; }
		[Required(ErrorMessage = "Confirm password is required")]
		[MinLength(6, ErrorMessage = "Confirm password must be at least 6 characters")]
		[Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
		public string ConfirmPassword { get; set; }
		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid email address format")]
		public string Email { get; set; }
		public string Fullname { get; set; }
		public string? Address { get; set; }
		public DateTime Birth { get; set; }
		public string Phone { get; set; }
	}
}
