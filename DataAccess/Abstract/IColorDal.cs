using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IColorDal : IEquatable<Color>
    {
        List<Color> GetAll(Expression<Func<Color,bool>> filter = null);
        //Listeden verilecek filtreye göre araba renklerini getiren method
        Color Get(Expression<Func<Color,bool>> filter);
        //Listeden girilecek filtreye uygun araba renklerini çekecek olan method
        void Add(Color entity);
        void Update(Color entity);
        void Delete(Color entity);
    }
}
