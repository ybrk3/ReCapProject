using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
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
        IFileHelper _fileHelper; //Resimi yükeleyecek
        ICarImageDal _carImage;  //Resimi server'a yükleyecek
        public CarImageManager(IFileHelper fileHelper, ICarImageDal carImage)
        {
            _fileHelper = fileHelper;
            _carImage = carImage;
        }
        [SecuredOperation("car.add, admin")]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageCount(carImage.CarID));
            if (result == null)
            {
                return result;
            }

            //sql için uzantısı alınır
            carImage.ImagePath = _fileHelper.Add(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImage.Add(carImage);
            return new SuccessResult(Messages.ImageUploaded);
        }

        public IResult Delete(CarImage carImage)
        {

            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carImage.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImage.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = _carImage.GetAll(c=> c.Id == carId).Count;
            if (result>0)
            {
                return new SuccessDataResult<List<CarImage>>(_carImage.GetAll(c => c.CarID == carId));
            }
          
            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarID = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImage.Get(c => c.Id == imageId));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            _fileHelper.Update(file, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
            _carImage.Update(carImage);
            return new SuccessResult();
        }

        //Business Rules
        private IResult CheckCarImageCount(int carId)
        {
            var result = _carImage.GetAll(c => c.CarID == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImageCountExceeded);
            }
            return new SuccessResult();
        }

       private IResult CheckCarImageExtension(IFormFile file)
        {
            string type = Path.GetExtension(file.FileName);
            if (type != ".jpeg" && type != ".png" && type != ".jpg")
            {
                return new ErrorResult(Messages.InvalidImageExtension);
            }
            return new SuccessResult();
        }
        


    }
}
