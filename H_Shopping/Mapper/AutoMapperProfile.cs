using AutoMapper;
using H_Shopping.DTO.Request;
using H_Shopping.DTO.Response;
using H_Shopping.Models;

namespace H_Shopping.Mapper
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<ProductModel, ProductResponse>().ReverseMap();
			CreateMap<AppUser, RegisterRequest>().ReverseMap();
			CreateMap<BrandModel, BrandModel>();
		}
	}
}
