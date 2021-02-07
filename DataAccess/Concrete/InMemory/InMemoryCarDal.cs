using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
                new Car{ID = 1, BrandId = 1, ColorId = 1, ModelYear = 2010, DailyPrice = 1000, Description = "Description"},
                new Car{ID = 2, BrandId = 1, ColorId = 1, ModelYear = 2016, DailyPrice = 999, Description = "Description1"},
                new Car{ID = 3, BrandId = 2, ColorId = 1, ModelYear = 2011, DailyPrice = 500, Description = "Description2"},
                new Car{ID = 4, BrandId = 2, ColorId = 2, ModelYear = 2017, DailyPrice = 2000, Description = "Description3"},
                new Car{ID = 5, BrandId = 2, ColorId = 2, ModelYear = 2012, DailyPrice = 1900, Description = "Description4"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }
        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.ID == car.ID);
            _cars.Remove(carToDelete);
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.ID == car.ID);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
        public List<Car> GetAll()
        {
            return _cars;
        }
        public Car GetById(int car_id)
        {
            Car car = _cars.SingleOrDefault(p => p.ID == car_id);
            return car;
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
