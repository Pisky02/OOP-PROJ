using Business.DTOs;

namespace Business.Services.Interfaces;

public interface ICartService
{
    Task<CartDto> GetCartAsync(int id);
}
