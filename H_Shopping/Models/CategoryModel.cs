using System.ComponentModel.DataAnnotations;

namespace H_Shopping.Models
{
	public class CategoryModel
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "Category name is required")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Description is required")]
		[MinLength(4, ErrorMessage = "Description must be at least 4 character")]
		public string Description { get; set; }
		public string Slug { get; set; }
		public int Status { get; set; }
	}
}
