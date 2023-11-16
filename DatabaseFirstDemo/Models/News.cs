using System;
using System.Collections.Generic;

namespace DatabaseFirstDemo.Models;

public partial class News
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string SubjectContent { get; set; }

    public DateTime DateUpdate { get; set; }

    public bool? Status { get; set; }

    public string Avatar { get; set; }

    public int UserId { get; set; }

    public virtual NewsCategory Category { get; set; }

    public virtual User User { get; set; }
}
