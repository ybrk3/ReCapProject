using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
                //addedEntity'e context'deki entity verilir ve bunun ekleneceği bildirilir.

            }
        }

        public void Delete(Car entity)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
                //addedEntity'e context'deki entity verilir ve bunun silineceği bildirilir.

            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                //addedEntity'e context'deki entity verilir ve bunun güncelleneceği bildirilir.

            }
        }
    }
}
