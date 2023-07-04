using CartService.Domain.Entity;
using Microsoft.AspNetCore.Identity;

namespace CartService.CartService.Host.Routes;

public static class CartRouter
{
    public static WebApplication AddCartRouter(this WebApplication application)
    {
        var cartGroup = application.MapGroup("/api/cart");
        cartGroup.MapGet(pattern: "/{userId:long}", handler: GetCart);
        cartGroup.MapPost(pattern: "/", handler: AddToCart);
        cartGroup.MapPut(pattern: "/", handler: UpdateCartItemQuantity);
        cartGroup.MapDelete(pattern: "/{userId:long}", handler: RemoveFromCart);
       // cartGroup.MapDelete(pattern: "/{userId:long}/clear", handler: ClearCart);

        return application;
    }
    private static IResult GetCart(long id, ICartManager cartManager)
    {
        var cart = cartManager.GetCartAsync(id);
        return cart is null
            ? Results.NotFound()
            : Results.Ok(cart);
    }
    private static IResult AddToCart(CartItem cartItem, ICartManager cartManager)
    {
        var createdCart = cartManager.AddToCartAsync(cartItem);
        return Results.Ok(createdCart);
    }

    private static IResult UpdateCartItemQuantity(CartItem cartItem, ICartManager cartManager)
    {
        var updatedCart = cartManager.UpdateCartItemQuantityAsync(cartItem);
        return updatedCart is null
            ? Results.NotFound()
            : Results.Ok(updatedCart);
    }
   
    private static IResult RemoveFromCart(long userId, long bookId, ICartManager cartManager)
    {
        var deletedCartItem = cartManager.RemoveFromCartAsync(userId);
        return deletedCartItem is null
            ? Results.NotFound()
            : Results.Ok(deletedCartItem);
    }
    /*private static IResult ClearCart(long userid, ICartManager cartManager)
    {
        var deletedCart = cartManager.ClearCartAsync(userid);
        return deletedCart is null
            ? Results.NotFound()
            : Results.Ok(deletedCart);
    }*/
}
