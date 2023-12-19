using DatabaseFirstDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo.Repository
{
    public interface IProductsRepository
    {
        IEnumerable<Product> GetAll();
        void Insert(Product products);
        void Update(Product products);
        Product GetById(int id);
        void Delete(Product products);
        IEnumerable<ProductCategory> GetAllProductsCategory();
        bool ChangeStatus(int id);
        IEnumerable<Product> GetProductsByKeyword(string keyword, string sortBy, int? categoryId);
    }
}
