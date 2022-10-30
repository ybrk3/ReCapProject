using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofact.Performance;
using Core.Aspects.Autofact.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

       
        public IResult Add(IFormFileCollection formFiles, int carId)
        {
            CarImage carImage = new CarImage();
            var result = false;
            foreach (var formFile in formFiles)
            {
                carImage.ImagePath = FileHelperManager.Add(formFile);
                carImage.CarId = carId;
                carImage.Date = DateTime.Now;
                _carImageDal.Add(carImage);
                result = true;
              
            }
            if (result)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }
        
        public IResult Delete(CarImage carImage)
        {
            FileHelperManager.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarImage> GetCarImageById(int id)
        {
            throw new NotImplementedException();
        }
       
        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return new ErrorDataResult<CarImage>(result.Message);
            }
            carImage.ImagePath = FileHelperManager.Update(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

      

        // Business Rules

        private IResult CheckImageLimitExceeded(int carId)
        {
            var carImageCount = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (carImageCount >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }


    }
}
