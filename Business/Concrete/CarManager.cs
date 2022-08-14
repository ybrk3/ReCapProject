﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Color.Concrete;
using Color.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarSevice
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.CarName.Length>=2 && car.DailyPrice>0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            return new ErrorResult(Messages.InvalidCarName);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<Car> GetById(int id)
        {
            var result = _carDal.Get(c=> c.Id==id);
            if (result==null)
            {
                return new ErrorDataResult<Car>(Messages.CarNotFound);
            }
            return new SuccessDataResult<Car>(result);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandAndColorIdDetail(int brandId, int colorId)
        {
            var result = _carDal.GetCarDetails(c => c.BrandId == brandId && c.ColorId == colorId);
            if (result==null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.CarNotFound);
            }
            return new SuccessDataResult<List<CarDetailDto>>(result, Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId);
            if (result==null)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarNotFound);
            }
            return new SuccessDataResult<List<Car>>(result, Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandIdDetail(int brandId)
        {
            var result = _carDal.GetCarDetails(c => c.BrandId == brandId);
            if (result==null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.CarNotFound);
            }
            return new SuccessDataResult<List<CarDetailDto>>(result, Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            var result = _carDal.GetAll(c => c.BrandId == id);
            if (result == null)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarNotFound);
            }
            return new SuccessDataResult<List<Car>>(result, Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorIdDetail(int colorId)
        {
            var result = _carDal.GetCarDetails(c => c.BrandId == colorId);
            if (result == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.CarNotFound);
            }
            return new SuccessDataResult<List<CarDetailDto>>(result, Messages.CarsListed);
        }


        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
