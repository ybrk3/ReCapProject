using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null);
        Brand Get(Expression<Func<Brand, bool>> filter);
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(Brand brand);
    }
}
