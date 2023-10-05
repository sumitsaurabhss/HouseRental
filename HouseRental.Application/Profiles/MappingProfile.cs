using AutoMapper;
using HouseRental.Application.DTOs.HouseDtos;
using HouseRental.Application.DTOs.RentalDtos;
using HouseRental.Application.DTOs.UserDtos;
using HouseRental.Domain.Entities;

namespace HouseRental.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterDto, User>();

            CreateMap<UserLoginDto, User>();

            CreateMap<User, UserDetailsDto>();

            CreateMap<HouseCreateDto, House>();

            CreateMap<House, HouseGetDto>();

            CreateMap<RentalCreateDto, Rental>()
                .ForMember(dest => dest.RentalStartDate, opt => opt.MapFrom(src => DateTime.Today.AddMonths(1)))
                .ForMember(dest => dest.RentalEndDate, opt => opt.MapFrom(src => DateTime.Today.AddMonths(src.DurationInMonths)));

            CreateMap<Rental, RentalGetDtoForUser>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.House.Type))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.House.Address));

            CreateMap<Rental, RentalGetDtoForAdmin>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.House.Type))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.House.Address))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name));
        }
    }
}
