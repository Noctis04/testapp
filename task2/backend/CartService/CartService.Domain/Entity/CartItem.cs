using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Domain.Entity;

public class CartItem
{
    [Key]
    public long UserId { get; set; }
    public long BookId { get; set; }
    public string BookTitle { get; set; } = "";
    public int Price { get; set; }
    public int Quantity { get; set; }
}