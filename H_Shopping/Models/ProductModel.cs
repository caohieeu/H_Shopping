using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H_Shopping.Models
{
	public class ProductModel
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "")]
		[MinLength(4, ErrorMessage = "Name must be at least 4 character")]
		public string Name { get; set; }
		[Required]
		[MinLength(10, ErrorMessage = "Name must be at least 10 character")]
		public string Description { get; set; }
		public decimal Price { get; set; } = 0;
		public long Stock {  get; set; }
		public DateTime DateCreated { get; set; }
		public int? BrandId { get; set; }
		public int? CategoryId { get; set; }
		[ForeignKey("BrandId")]
		public BrandModel Brand { get; set; }
        [ForeignKey("CategoryId")]
        public CategoryModel Category { get; set; }

    }
}
