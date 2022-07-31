using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Data_Access;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IColorDal : IEntityRepository<Color>
    {
        
    }
}
