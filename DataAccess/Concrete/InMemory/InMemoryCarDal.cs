using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ Id=1, BrandId=2, ColorId=6746, DailyPrice=30, ModelYear=2015, Description="Best Car1"},
                new Car{ Id=2, BrandId=3, ColorId=3642, DailyPrice=80, ModelYear=2018, Description="Best Car2"},
                new Car{ Id=3, BrandId=2, ColorId=3174, DailyPrice=20, ModelYear=2005, Description="Best Car3"},
                new Car{ Id=4, BrandId=5, ColorId=5475, DailyPrice=120, ModelYear=2020, Description="Best Car4"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var deletecar = _cars.SingleOrDefault(c => c.Id == car.Id);

            _cars.Remove(deletecar);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            var updatecar = _cars.SingleOrDefault(c => c.Id == car.Id);

            updatecar.ModelYear = car.ModelYear;
            updatecar.DailyPrice = car.DailyPrice;
            updatecar.Description = car.Description;
        }
    }
}
