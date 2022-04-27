using ApplicationCore.Entities.ShipAggreate;
using ApplicationCore.Entities.UserAggreate;
using AutoMapper;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<UserDTO, User>().ReverseMap();
		CreateMap<ShipDTO, Ship>().ReverseMap();
		
	}
}