using DatabaseFirstDemo.Models;
using X.PagedList;

namespace WebDemo14112023.Areas.Admin.Models
{
    public class ProductsCategoryUsers
    {
        public ICollection<ProductCategory> ProductsCategory { get; set; }
        public IPagedList<Product> Products { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
