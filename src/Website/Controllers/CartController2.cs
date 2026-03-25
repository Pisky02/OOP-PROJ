using Business.DTOs;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController(ICartService _cartService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<CartDto>> GetCart(int id)
    {
        try
        {
            var cart = await _cartService.GetCartAsync(id);
            return Ok(cart);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound($"Kosik s ID {id} neexistuje.");
        }
    }
}
