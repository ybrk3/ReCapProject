using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data_Access
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        //Listeden verilecek filtreye göre nesneleri listeleyen method
        T Get(Expression<Func<T, bool>> filter);
        //Listeden girilecek filtreye uygun nesneleri çekecek olan method
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
