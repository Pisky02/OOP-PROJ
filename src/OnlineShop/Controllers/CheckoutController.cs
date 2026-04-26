using Microsoft.AspNetCore.Mvc;
using OnlineShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models;

namespace OnlineShop.Controllers;

public class CheckoutController : Controller
{
    private readonly ApplicationDbContext _db;
    public CheckoutController(ApplicationDbContext db) => _db = db;

    public async Task<IActionResult> Index()
    {
        return View();
    }
}
