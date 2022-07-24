using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarSevice
    {
        List<Car> GetCarsByColor(int colorID);
        List<Car> GetCarsByBrandID(int brandID);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
