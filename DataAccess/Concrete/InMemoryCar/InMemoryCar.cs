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

namespace DataAccess.Concrete.InMemoryCar
{
    public class InMemoryCar : ICarDal
    {
        List<Car> _cars;
        public InMemoryCar()
        {
            _cars = new List<Car> {
                new Car { Id=1, BrandId=1, ModelYear="2021", DailyPrice=325,Description="Audi A4, diesel, dijital klima, hız sabitleme, şerit takip vardır." },
                new Car { Id=2, BrandId=1, ModelYear="2022", DailyPrice=450,Description="Audi A3, diesel, dijital klima, hız sabitleme, şerit takip vardır." },
                new Car { Id=3, BrandId=2, ModelYear="2021", DailyPrice=250,Description="Ford Focus, diesel, dijital klima, hız sabitleme, şerit takip vardır." },
                new Car { Id=4, BrandId=2, ModelYear="2021", DailyPrice=275,Description="Ford Fiesta, diesel, dijital klima, hız sabitleme, şerit takip vardır." },
                new Car { Id=5, BrandId=3, ModelYear="2022", DailyPrice=2150,Description="Fiat Linea, diesel, dijital klima, hız sabitleme, şerit takip vardır." }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.FirstOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public void Delete(Car car)
        {
            Car carToDelete = null;
            carToDelete = _cars.FirstOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
