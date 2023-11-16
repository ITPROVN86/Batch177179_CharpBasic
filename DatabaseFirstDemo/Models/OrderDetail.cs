using System;
using System.Collections.Generic;

namespace DatabaseFirstDemo.Models;

public partial class OrderDetail
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal Price { get; set; }

    public int Quanlity { get; set; }

    public virtual Order Order { get; set; }

    public virtual Product Product { get; set; }
}
