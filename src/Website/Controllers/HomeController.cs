using Microsoft.AspNetCore.Mvc;
using OnlineShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models;

namespace OnlineShop.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _db;
    public HomeController(ApplicationDbContext db) => _db = db;

    public async Task<IActionResult> Index()
    {
        var products = await _db.Products.ToListAsync();
        return View(products);
    }
}
