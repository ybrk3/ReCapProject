using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
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
        private RentalCarContext rentalCarContext;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public CarManager(RentalCarContext rentalCarContext)
        {
            this.rentalCarContext = rentalCarContext;
        }

        public void Add(Car car)
        {
            //Koşullar
            if (car.CarName.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Araba ismi 2 veya 2 karakterin üzerinde ve Günlük ücret 0'ın üzerinde olmalıdır");
            }

        }

        public void Delete(Car car)
        {
            //Koşullar
            _carDal.Delete(car);
        }



        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _carDal.GetAll(filter);
        }


        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return _carDal.Get(filter);
        }



        public void Update(Car car)
        {
            //Koşullar
            if (car.CarName.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Update(car);
            }
            else
            {
                Console.WriteLine("Araba ismi 2 karakterin üzerinde ve Günlük ücret 0'ın üzerinde olmalıdır");
            }
        }

       
    }
}
