using DatabaseFirstDemo.Models;
using X.PagedList;

namespace WebDemo14112023.Areas.Admin.Models
{
    public class NewsCategoryUsers
    {
        public ICollection<NewsCategory> NewsCategory { get; set; }
        public IPagedList<News> News { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
