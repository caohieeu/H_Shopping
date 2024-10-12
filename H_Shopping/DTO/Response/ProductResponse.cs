using H_Shopping.Models;

namespace H_Shopping.DTO.Response
{
	public class ProductResponse : ProductModel
	{
		public List<ProductImageModel> images { get; set; }
		public ProductResponse() : base()
		{
			images = new List<ProductImageModel>();
		}
	}
}
