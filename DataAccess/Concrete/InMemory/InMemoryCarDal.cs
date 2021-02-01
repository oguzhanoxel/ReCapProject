using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
                new Car{Id = 1, BrandId = 1, ColorId = 1, ModelYear = new DateTime(2010), DailyPrice = 1000, Description = "Description"},
                new Car{Id = 2, BrandId = 1, ColorId = 1, ModelYear = new DateTime(2016), DailyPrice = 999, Description = "Description1"},
                new Car{Id = 3, BrandId = 2, ColorId = 1, ModelYear = new DateTime(2011), DailyPrice = 500, Description = "Description2"},
                new Car{Id = 4, BrandId = 2, ColorId = 2, ModelYear = new DateTime(2017), DailyPrice = 2000, Description = "Description3"},
                new Car{Id = 5, BrandId = 2, ColorId = 2, ModelYear = new DateTime(2012), DailyPrice = 1900, Description = "Description4"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }
        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
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
            Car car = _cars.SingleOrDefault(p => p.Id == car_id);
            return car;
        }
    }
}
