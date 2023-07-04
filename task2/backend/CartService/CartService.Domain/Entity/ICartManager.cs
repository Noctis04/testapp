namespace CartService.Domain.Entity;

public interface ICartManager
{

    /* CartItem AddCartItem(CartItem cartItem);

     CartItem UpdateCartItem(CartItem cart);

     CartItem RemoveCartItem(long id);


     Cart? GetByIdCart(long id);

     Cart CraeteCart(Cart cart);

     Cart? UpdateCart(Cart cart);

     Cart? DeleteCart(long id);
     object AddCartItem(Cart cart);*/
    Cart? GetCartAsync(long userId);
    CartItem AddToCartAsync(CartItem cartItem);
    CartItem? UpdateCartItemQuantityAsync(CartItem cartItem);
    CartItem? RemoveFromCartAsync(long userId);
    //CartItem ClearCartAsync(long userId);
}
