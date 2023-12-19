using DatabaseFirstDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo.DAO
{
    public class ProductsDao
    {
        private static ProductsDao instance;
        private static readonly object instanceLock = new object();
        public static ProductsDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductsDao();
                    }
                    return instance;
                }
            }
        }

        public List<Product> GetAll()
        {
            List<Product> news;
            try
            {
                using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
                news = stock.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return news;
        }


        public IEnumerable<Product> GetProductsByKeyword(string keyword, string sortBy, int? categoryId)
        {
            List<Product> products = new List<Product>();
            try
            {
                ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
                IQueryable<Product> newsQuery = stock.Products;
                if (!String.IsNullOrEmpty(keyword))
                {
                    newsQuery = newsQuery.Where(u => u.Name != null && u.Name.ToLower().Contains(keyword)); // Remove ToList() here
                }

                switch (sortBy)
                {
                    case "name":
                        newsQuery = (Microsoft.EntityFrameworkCore.DbSet<Product>)newsQuery.OrderBy(o => o.Name);
                        break;
                    case "namedesc":
                        newsQuery = (Microsoft.EntityFrameworkCore.DbSet<Product>)newsQuery.OrderByDescending(o => o.Name);
                        break;
                    default:
                        break;
                }
                if (categoryId != null)
                {
                    products = newsQuery.Where(u => u.CategoryId == categoryId).ToList();
                }
                else
                {
                    products = newsQuery.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public Product GetById(int? id)
        {
            Product products;
            try
            {
                using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
                products = stock.Products.SingleOrDefault(r => r.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }


        public void Insert(Product products)
        {
            using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
            using (var transaction = stock.Database.BeginTransaction())
            {
                try
                {

                    stock.Add(products);
                    stock.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public void Update(Product products)
        {
            using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
            using (var transaction = stock.Database.BeginTransaction())
            {
                try
                {
                    stock.Entry<Product>(products).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    stock.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public IEnumerable<ProductCategory> GetAllProductsCategory()
        {
            using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
            return stock.ProductCategories.ToList();
        }

        public void Delete(Product products)
        {
            try
            {
                using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
                var us = stock.Products.SingleOrDefault(c => c.Id == products.Id);
                stock.Remove(us);
                stock.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ChangeStatus(int id)
        {
            using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
            var news = stock.Products.Find(id);
            news.Status = !news.Status;
            stock.SaveChanges();
            return (bool)news.Status;
        }
    }
}
