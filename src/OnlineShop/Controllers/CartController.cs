using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Infrastructure.Data;
using OnlineShop.Core.Models;

namespace OnlineShop.Controllers;

public class CartController : Controller
{
    private readonly ApplicationDbContext _db;
    public CartController(ApplicationDbContext db) => _db = db;

    private string GetSessionId()
    {
        if (!HttpContext.Request.Cookies.TryGetValue("SessionId", out var sessionId))
        {
            sessionId = Guid.NewGuid().ToString();
            HttpContext.Response.Cookies.Append("SessionId", sessionId);
        }
        return sessionId!;
    }

    public async Task<IActionResult> Index()
    {
        var sessionId = GetSessionId();
        var items = await _db.CartItems.Include(ci => ci.Product).Where(ci => ci.SessionId == sessionId).ToListAsync();
        return View(items);
    }

    [HttpPost]
    public async Task<IActionResult> Add(int productId, int quantity = 1)
    {
        var sessionId = GetSessionId();
        var item = await _db.CartItems.FirstOrDefaultAsync(ci => ci.ProductId == productId && ci.SessionId == sessionId);
        if (item == null)
        {
            item = new CartItem { ProductId = productId, Quantity = quantity, SessionId = sessionId };
            _db.CartItems.Add(item);
        }
        else
        {
            item.Quantity += quantity;
            _db.CartItems.Update(item);
        }
        await _db.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Remove(int id)
    {
        var sessionId = GetSessionId();
        var item = await _db.CartItems.FirstOrDefaultAsync(ci => ci.Id == id && ci.SessionId == sessionId);
        if (item != null)
        {
            _db.CartItems.Remove(item);
            await _db.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }
}
