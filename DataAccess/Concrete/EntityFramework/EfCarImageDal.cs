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
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, ReCapProjectDBContext>, ICarImageDal
    {
        public List<CarImageDetailDto> GetCarImageDetails()
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var result = from carImage in context.CarImages
                             join car in context.Cars on carImage.CarID equals car.ID
                             join brand in context.Brands on car.BrandID equals brand.ID
                             join color in context.Colors on car.ColorID equals color.ID
                             select new CarImageDetailDto
                             {
                                 ID = carImage.ID,
                                 CarName = car.Name,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 ImagePath = carImage.ImagePath,
                                 Date = carImage.Date,
                             };
                return result.ToList();
            }
        }
    }
}
