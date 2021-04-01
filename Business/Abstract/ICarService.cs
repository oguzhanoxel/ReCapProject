using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);
        IDataResult<List<Car>> GetCarsByBrandId(int brand_id);
        IDataResult<List<Car>> GetCarsByColorId(int color_id);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrand(int brand_id);
        IDataResult<List<CarDetailDto>> GetCarDetailsFilter(int? brand_id, int? color_id);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColor(int color_id);
        IDataResult<CarDetailDto> GetCarDetail(int carId);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);

    }
}
