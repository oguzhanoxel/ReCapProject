using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            string s = "";
            var validator = new CarValidator();
            ValidationResult results = validator.Validate(car);
            if (!results.IsValid)
            {
                IList<ValidationFailure> failures = results.Errors;
                foreach(ValidationFailure item in failures)
                {
                    s += item.ErrorMessage;
                }
                return new ErrorResult(s);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int car_id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.ID == car_id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brand_id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandID == brand_id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int color_id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorID == color_id));
        }

        public IResult Update(Car car)
        {
            if (car.Name.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
