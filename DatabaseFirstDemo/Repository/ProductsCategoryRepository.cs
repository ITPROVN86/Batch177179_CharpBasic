using DatabaseFirstDemo.DAO;
using DatabaseFirstDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo.Repository
{
    public class ProductsCategoryRepository: IProductsCategoryRepository
    {
        public IEnumerable<ProductCategory> GetAll()=> ProductCategoryDao.Instance.GetAll();
        public void Insert(ProductCategory productCategory) => ProductCategoryDao.Instance.Insert(productCategory);
        public void Update(ProductCategory productCategory) => ProductCategoryDao.Instance.Update(productCategory);
        public ProductCategory GetById(int id) => ProductCategoryDao.Instance.GetById(id);
        public void Delete(ProductCategory productCategory) => ProductCategoryDao.Instance.Delete(productCategory);
    }
}
