using Microsoft.EntityFrameworkCore;
using OnlineShop.Infrastructure.Data;
using OnlineShop.Core.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=online_shop.db"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Ensure database is created, apply migrations and seed some sample products for the course demo
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    try
    {
        db.Database.Migrate();

        if (!db.Products.Any())
        {
            db.Products.AddRange(
                new Product { Name = "Basic T-Shirt", Description = "Cotton t-shirt", Price = 12.99m },
                new Product { Name = "Coffee Mug", Description = "Ceramic mug", Price = 7.50m },
                new Product { Name = "Sticker Pack", Description = "Set of stickers", Price = 3.00m }
            );
            db.SaveChanges();
        }
    }
    catch
    {
        // swallow errors for the simple lab project; inspect logs in real projects
    }
}

app.Run();
