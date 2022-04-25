using ApplicationCore.Entities.ShipAggreate;
using ApplicationCore.Entities.UserAggreate;
using AutoMapper;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<UserDTO, User>().ReverseMap();
		CreateMap<ShipDTO, Ship>().ReverseMap();
		
	}
}