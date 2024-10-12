using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H_Shopping.Models
{
	public class UserModel
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "Username is required")]
		[MinLength(6, ErrorMessage ="Username must be at least 6 characters")]
		public string UserName { get; set; }
		[Required(ErrorMessage = "Password is required")]
		[MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
		public string Password { get; set; }
		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid email address format")]
		public string Email { get; set; }
		public string Fullname { get; set; }
		public string? Address { get; set; }
		public DateTime Birth { get; set; }
		public string Phone { get; set; }
		public string? Avatar { get; set; }
		public int? RoleId { get; set; }
		[ForeignKey("RoleId")]
		public RoleModel Role { get; set; }
	}
}
