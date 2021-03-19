using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandID equals brand.ID
                             join color in context.Colors on car.ColorID equals color.ID
                             select new CarDetailDto
                             {
                                 ID = car.ID,
                                 BrandID = brand.ID,
                                 ColorID = color.ID,
                                 CarName = car.Name,
                                 ModelYear = car.ModelYear,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 Description = car.Description,
                                 DailyPrice = car.DailyPrice,
                                 ImagePaths = (from carImage in context.CarImages where carImage.CarID == car.ID select carImage.ImagePath).ToList(),
                             };
                return result.ToList();
            }
        }
    }
}
