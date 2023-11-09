using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess
{
    public class CarDAO
    {
        private static CarDAO instance = null;
        private static readonly object instanceLock = new object();
        public static CarDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CarDAO();
                }
                return instance;
            }
        }

        public IEnumerable<Car> GetCarList()
        {
            var list = new List<Car>();
            try
            {
                using var context = new MyStockContext();
                list = context.Cars.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public Car GetCarByID(int id)
        {
            Car car = null;
            try
            {
                using var context = new MyStockContext();
                car = context.Cars.SingleOrDefault(c => c.CarId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return car;
        }

        public void AddNew(Car car)
        {
            try
            {
                using var context = new MyStockContext();
                context.Cars.Add(car);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Car car)
        {
            try
            {
                Car c = GetCarByID(car.CarId);
                if (c != null)
                {
                    using var context = new MyStockContext();
                    context.Cars.Update(car);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(Car car)
        {
            try
            {
                Car c = GetCarByID(car.CarId);
                if (c != null)
                {
                    using var context = new MyStockContext();
                    context.Cars.Remove(car);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
