using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseFirstDemo.Models;

public partial class Order
{
    [Display(Name ="Mã đặt hàng")]
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime DateBuy { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual User User { get; set; }
}
