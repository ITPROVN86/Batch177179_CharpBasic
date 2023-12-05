using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseFirstDemo.Models;

public partial class User
{
    public int UserId { get; set; }

    [Display(Name ="Tên đăng nhập")]
    public string UserName { get; set; }

    public string Password { get; set; }

    public int RoleId { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<News> News { get; set; } = new List<News>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual Role Role { get; set; }

    public virtual UserDetail UserDetail { get; set; }
}
