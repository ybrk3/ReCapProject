using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Data_Access;
using Color.Concrete;

namespace DataAccess.Abstract
{
    public interface IColorDal : IEntityRepository<Color.Concrete.Color>
    {
        
    }
}
