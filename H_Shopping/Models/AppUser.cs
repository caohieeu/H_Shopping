using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace H_Shopping.Models
{
	public class AppUser : IdentityUser
	{
		[Required(ErrorMessage = "Username is required")]
		[MinLength(6, ErrorMessage = "Username must be at least 6 characters")]
		public override string? UserName { get => base.UserName; set => base.UserName = value; }
		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid email address format")]
		public override string? Email { get => base.Email; set => base.Email = value; }
		public string? Fullname { get; set; }
		public string? Address { get; set; }
		public DateTime? Birth { get; set; }
		public string? Avatar { get; set; }
	}
}
