using CartService.Domain;
using CartService.Domain.Entity;
using CartService.Infrastructure.Context;
using CartService.Infrastructure.Managers;
using Microsoft.EntityFrameworkCore;

namespace CartService.Infrastructure.Managers;

public class CartManager : ICartManager
{
    /*private readonly CartContext _cartContext;

    public CartManager(CartContext cartContext)
    {
        _cartContext = cartContext;
    }
    public Cart? GetCart(long id)
    {
        return _cartContext.Carts.FirstOrDefault(x => x.Id == id);
    }
    public async Task AddToCartAsync(long userId, long bookId, int quantity)
    {
        // Реализуйте логику для добавления книги в корзину
        var cartItem = new CartItem
        {
            UserId = userId,
            BookId = bookId,
            Quantity = quantity
        };

        _cartContext.CartItems.Add(cartItem);
        await _cartContext.SaveChangesAsync();
    }*/
    private readonly CartContext _dbContext;

    public CartManager(CartContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Cart? GetCartAsync(long id)
    {
        return _dbContext.Carts.FirstOrDefault(x => x.Id == id);
    }

    public CartItem AddToCartAsync(CartItem cartItem)
    {
        var entry = _dbContext.Add(cartItem);
        _dbContext.SaveChanges();
        return entry.Entity;
    }

    public CartItem? UpdateCartItemQuantityAsync(CartItem cartItem)
    {
        var existingItem = _dbContext.CartItems.FirstOrDefault(x=>x.BookId == cartItem.BookId);
        if (existingItem is null)
        {
            return null;
        }
        existingItem.Quantity = cartItem.Quantity;
        var entry = _dbContext.Update(cartItem);
        _dbContext.SaveChanges();
        return entry.Entity;
    }

    public CartItem? RemoveFromCartAsync(long userId)
    {
        var existingUser = _dbContext.CartItems.FirstOrDefault(x => x.UserId == userId);
       
        if (existingUser is null )
        {
            return null;
        }
        var entry = _dbContext.Remove(existingUser);
        _dbContext.SaveChanges();
        return entry.Entity;
    }

    

    

}
