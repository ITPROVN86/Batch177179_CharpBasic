using DatabaseFirstDemo.DAO;
using DatabaseFirstDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo.Repository
{
    public class ProductsRepository: IProductsRepository
    {
        public IEnumerable<Product> GetAll()=>ProductsDao.Instance.GetAll();
        public void Insert(Product products) => ProductsDao.Instance.Insert(products);
        public void Update(Product products) => ProductsDao.Instance.Update(products);
        public Product GetById(int id) => ProductsDao.Instance.GetById(id);
        public void Delete(Product products) => ProductsDao.Instance.Delete(products);
        public IEnumerable<ProductCategory> GetAllProductsCategory() => ProductsDao.Instance.GetAllProductsCategory();
        public bool ChangeStatus(int id) => ProductsDao.Instance.ChangeStatus(id);
        public IEnumerable<Product> GetProductsByKeyword(string keyword, string sortBy, int? categoryId) => ProductsDao.Instance.GetProductsByKeyword(keyword, sortBy, categoryId);
    }
}
