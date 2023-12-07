using DatabaseFirstDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo.DAO
{
    public class NewsDao
    {
        private static NewsDao instance;
        private static readonly object instanceLock = new object();
        public static NewsDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new NewsDao();
                    }
                    return instance;
                }
            }
        }

        public List<News> GetAll()
        {
            List<News> news;
            try
            {
                using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
                news = stock.News.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return news;
        }


        public List<News> GetNewsByKeyword(string keyword, string sortBy, int? categoryId)
        {
            List<News> news = new List<News>();
            try
            {
                ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
                var newsQuery = stock.News;
                if (!String.IsNullOrEmpty(keyword))
                {
                    newsQuery = (Microsoft.EntityFrameworkCore.DbSet<News>)stock.News.Where(u => u.Title.ToLower().Contains(keyword));
                }

                switch (sortBy)
                {
                    case "title":
                        newsQuery = (Microsoft.EntityFrameworkCore.DbSet<News>)newsQuery.OrderBy(o => o.Title);
                        break;
                    case "titledesc":
                        newsQuery = (Microsoft.EntityFrameworkCore.DbSet<News>)newsQuery.OrderByDescending(o => o.Title);
                        break;
                    default:
                        break;
                }
                if (categoryId != null)
                {
                    news = newsQuery.Where(u => u.CategoryId == categoryId).ToList();
                }
                else
                {
                    news = newsQuery.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return news;
        }

        public News GetById(int? id)
        {
            News news;
            try
            {
                using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
                news = stock.News.SingleOrDefault(r => r.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return news;
        }

      
        public void Insert(News news)
        {
            using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
            using (var transaction = stock.Database.BeginTransaction())
            {
                try
                {

                    stock.Add(news);
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

        public void Update(News news)
        {
            using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
            using (var transaction = stock.Database.BeginTransaction())
            {
                try
                {
                    stock.Entry<News>(news).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public IEnumerable<NewsCategory> GetAllNewsCategory()
        {
            using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
            return stock.NewsCategories.ToList();
        }

        public void Delete(News news)
        {
            try
            {
                using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
                var us = stock.News.SingleOrDefault(c => c.Id == news.UserId);
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
            var news = stock.News.Find(id);
            news.Status = !news.Status;
            stock.SaveChanges();
            return (bool)news.Status;
        }
    }
}
