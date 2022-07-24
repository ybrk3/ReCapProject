using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<Car> GetAll(Expression<Func<Car,bool>> filter = null);
        //Listeden verilecek filtreye göre arabaları getiren method
        Car Get(Expression<Func<Car,bool>> filter);
        //Listeden girilecek filtreye uygun arabaları çekecek olan method
        void Add(Car entity);
        void Update(Car entity);
        void Delete(Car entity);
    }
}
