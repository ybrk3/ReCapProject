using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        //Listeden verilecek filtreye göre nesneleri getiren method
        T Get(Expression<Func<T,bool>> filter);
        //Listeden girilecek filtreye uygun nesneyi çekecek olan method
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
