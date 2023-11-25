using DatabaseFirstDemo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo.DAO
{
    public class UsersDao
    {
        private static UsersDao instance;
        private static readonly object instanceLock = new object();
        public static UsersDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UsersDao();
                    }
                    return instance;
                }
            }
        }

        public List<User> GetAll()
        {
            List<User> user;
            try
            {
                using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
                user = stock.Users.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        public User GetById(int? id)
        {
            User user;
            try
            {
                using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
                user = stock.Users.SingleOrDefault(r => r.UserId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        public UserDetail GetByUserDetailId(int? id)
        {
            UserDetail userDetail;
            try
            {
                using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
                userDetail = stock.UserDetails.SingleOrDefault(r => r.UserId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userDetail;
        }

        public List<UserDetail> GetUserDetailAll()
        {
            List<UserDetail> listUserDetail;
            try
            {
                using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
                listUserDetail = stock.UserDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listUserDetail;
        }

        public void Insert(User user, UserDetail userDetail)
        {
            using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
            using (var transaction = stock.Database.BeginTransaction())
            {
                try
                {

                    stock.Add(user);
                    stock.Add(userDetail);
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

        public void InsertUser(User user)
        {
            using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
            using (var transaction = stock.Database.BeginTransaction())
            {
                try
                {

                    stock.Add(user);
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

        public void InsertUserDetail(UserDetail user)
        {
            using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
            using (var transaction = stock.Database.BeginTransaction())
            {
                try
                {

                    stock.Add(user);
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

        public void Update(User user, UserDetail userDetail)
        {
            using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
            using (var transaction = stock.Database.BeginTransaction())
            {
                try
                {
                    stock.Entry<User>(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    stock.Entry<UserDetail>(userDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public void UpdateUser(User user)
        {
            using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
            using (var transaction = stock.Database.BeginTransaction())
            {
                try
                {
                    stock.Entry<User>(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public void UpdateUserDetail(UserDetail userDetail)
        {
            using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
            using (var transaction = stock.Database.BeginTransaction())
            {
                try
                {
                    stock.Entry<UserDetail>(userDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public IEnumerable<Role> GetAllRoles()
        {
            using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
            return stock.Roles.ToList();
        }

        public void Delete(User user)
        {
            try
            {
                using ProductMangementBatch177Context stock = new ProductMangementBatch177Context();
                var rl = stock.Users.SingleOrDefault(c => c.UserId == user.UserId);
                stock.Remove(rl);
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
            var user = stock.Users.Find(id);
            user.Status = !user.Status;
            stock.SaveChanges();
            return (bool)user.Status;
        }
    }
}
