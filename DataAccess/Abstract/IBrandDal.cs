using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBrandDal : IEntityRepository<Brand>
    {
        List<Brand> GetAll(Expression<Func<Brand,bool>> filter = null);
        //Listeden verilecek filtreye göre markaları getiren method
        Brand Get(Expression<Func<Brand,bool>> filter);
        //Listeden girilecek filtreye uygun markaları çekecek olan method
        void Add(Brand entity);
        void Update(Brand entity);
        void Delete(Brand entity);
    }
}
