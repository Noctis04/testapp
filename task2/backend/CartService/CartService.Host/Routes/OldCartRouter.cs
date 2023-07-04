using CartService.Domain.Entity;
using Microsoft.AspNetCore.Identity;

namespace CartService.CartService.Host.Routes;

public static class OldCartRouter
{
    public static WebApplication OldAddCartRouter(this WebApplication application)
    {
        // Производим группировку логики.
        var userGroup = application.MapGroup("/api/users");

        userGroup.MapGet(pattern: "/{id:long}", handler: GetCartById);
        userGroup.MapPost(pattern: "/", handler: AddItemToCart);
        userGroup.MapPost(pattern: "/", handler: CreateCart);
        userGroup.MapPut(pattern: "/", handler: UpdateCart);
        userGroup.MapPut(pattern: "/", handler: UpdateCartItem);
        userGroup.MapDelete(pattern: "/{id:long}", handler: DeleteCart);
        userGroup.MapDelete(pattern: "/{id:long}", handler: DeleteCartItem);

        return application;
    }
    private static IResult GetCartById(long id, ICartManager cartManager)
    {
        var cart = cartManager.GetByIdCart(id);
        return cart is null
            ? Results.NotFound()
            : Results.Ok(cart);
    }
    private static IResult AddItemToCart (CartItem cartItem, ICartManager cartManager) 
    {
        var createdItemCart = cartManager.AddCartItem(cartItem);
        return Results.Ok(createdItemCart);
    }
    private static IResult CreateCart(Cart cart, ICartManager cartManager)
    {
        var createdCart = cartManager.CraeteCart(cart);
        return Results.Ok(createdCart);
    }
    private static IResult UpdateCart(Cart cart, ICartManager cartManager)
    {
        var updatedCart = cartManager.UpdateCart(cart);
        return updatedCart is null
            ? Results.NotFound()
            : Results.Ok(updatedCart);
    }
    private static IResult UpdateCartItem(CartItem cartItem, ICartManager cartManager)
    {
        var updatedCartItem = cartManager.UpdateCartItem(cartItem);
        return updatedCartItem is null
            ? Results.NotFound()
            : Results.Ok(updatedCartItem);
    }
    private static IResult DeleteCart(long id, ICartManager cartManager)
    {
        var deletedCart = cartManager.DeleteCart(id);
        return deletedCart is null
            ? Results.NotFound()
            : Results.Ok(deletedCart);
    }
    private static IResult DeleteCartItem(long id, ICartManager cartManager)
    {
        var deletedCartItem = cartManager.RemoveCartItem(id);
        return deletedCartItem is null
            ? Results.NotFound()
            : Results.Ok(deletedCartItem);
    }

}
