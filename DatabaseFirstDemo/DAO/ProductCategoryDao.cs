using DatabaseFirstDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo.DAO
{
    public class ProductCategoryDao
    {
        private static ProductCategoryDao instance;
        private static readonly object instanceLock = new object();
        public static ProductCategoryDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductCategoryDao();
                    }
                    return instance;
                }
            }
        }

        public List<ProductCategory> GetAll()
        {
            List<ProductCategory> productsCategory;
            try
            {
                using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
                productsCategory = stock.ProductCategories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productsCategory;
        }

        public ProductCategory GetById(int? id)
        {
            ProductCategory productCategory;
            try
            {
                using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
                productCategory = stock.ProductCategories.SingleOrDefault(r => r.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productCategory;
        }

        public void Insert(ProductCategory productCategory)
        {
            try
            {
                using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
                stock.Add(productCategory);
                stock.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(ProductCategory productCategory)
        {
            try
            {
                using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
                stock.Entry<ProductCategory>(productCategory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                stock.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(ProductCategory productCategory)
        {
            try
            {
                using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
                var rl = stock.ProductCategories.SingleOrDefault(c => c.Id == productCategory.Id);
                stock.Remove(rl);
                stock.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
