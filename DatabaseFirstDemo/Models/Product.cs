using System;
using System.Collections.Generic;

namespace DatabaseFirstDemo.Models;

public partial class Product
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Avatar { get; set; }

    public int UserId { get; set; }

    public DateTime DateUpdate { get; set; }

    public decimal Price { get; set; }

    public int Quanlity { get; set; }

    public bool? Status { get; set; }

    public virtual ProductCategory Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual User User { get; set; }
}
