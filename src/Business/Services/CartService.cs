using AutoMapper;
using Business.DTOs;
using Business.Services.Interfaces;
using Database.Models;

namespace Business.Services;

internal class CartService(IMapper _mapper) : ICartService
{
    public async Task<CartDto> GetCartAsync(int id)
    {
        var cart = new Cart //tady by spravne melo byt volani do repository pro ziskani dat z databaze, ale pro ukazku to jenom vytvorime
        {
            Id = id,
            DateCreated = DateTime.Now,
        };
        if (cart == null)
        {
            throw new KeyNotFoundException();
        }

        var cartDto = _mapper.Map<CartDto>(cart);

        return cartDto;


    }
}
