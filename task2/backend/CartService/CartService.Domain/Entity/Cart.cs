using System.ComponentModel.DataAnnotations;
namespace CartService.Domain.Entity;

public class Cart
{
    [Key]
    public long Id { get; set; }

    public List<CartItem> BookItems { get; set; } = new List<CartItem>();

    public int TotalPrice => BookItems.Sum(item => item.Price * item.Quantity);
}

