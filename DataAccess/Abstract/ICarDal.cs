﻿using Core.Data_Access;
using Color.Concrete;
using Color.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter=null);
    }
}
