using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Car> GetCarsByBrandID(int brandID)
        {

            return _carDal.GetAll(c => c.Equals(brandID));
        }

        public List<Car> GetCarsByColor(int colorID)
        {
            return _carDal.GetAll(c => c.Equals(colorID));
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
