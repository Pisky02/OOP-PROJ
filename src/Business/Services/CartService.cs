using Business.DTOs;
using Business.Services.Interfaces;
using Database.Models;

namespace Business.Services;

//public class CartService(IMapper _mapper) : ICartService
public class CartService : ICartService
{
    public async Task<CartDto> GetCartAsync(int id)
    {
        var cart = new Cart // placeholder - should call repository in real implementation
        {
            Id = id,
            DateCreated = DateTime.Now,
        };

        if (cart == null)
        {
            throw new KeyNotFoundException();
        }

        // var cartDto = _mapper.Map<CartDto>(cart); // AutoMapper mapping (nugetka)
        var cartDto = new CartDto
        {
            Id = cart.Id,
            DateCreated = cart.DateCreated,
            CreatedBefore = DateTime.Now - cart.DateCreated
        };

        return await Task.FromResult(cartDto);
    }
}
