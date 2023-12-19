using DatabaseFirstDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo.Repository
{
    public interface IProductsCategoryRepository
    {
        IEnumerable<ProductCategory> GetAll();
        void Insert(ProductCategory productCategory);
        void Update(ProductCategory productCategory);
        ProductCategory GetById(int id);
        void Delete(ProductCategory productCategory);
    }
}
