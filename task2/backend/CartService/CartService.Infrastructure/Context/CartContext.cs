using Microsoft.EntityFrameworkCore;
using CartService.Domain.Entity;

namespace CartService.Infrastructure.Context;

public sealed class CartContext : DbContext
{
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<CartItem> CartItems => Set<CartItem>();

    public CartContext(DbContextOptions options) : base(options)
    {
        Database.Migrate();
    }
}
