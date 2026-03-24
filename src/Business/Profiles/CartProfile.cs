using AutoMapper;
using Business.DTOs;
using Database.Models;

namespace Business.Profiles;

public class CartProfile : Profile // AutoMapper Profile class (nugetka)
{
    public CartProfile()
    {
        CreateMap<Cart, CartDto>() // database.models.cars
            .ForMember(dest => dest.CreatedBefore, opt => opt.MapFrom(src => DateTime.Now - src.DateCreated));
    }
}
