using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Color.Concrete;
using Color.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentalCarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var result = from cu in context.Customers
                             join us in context.Users
                             on cu.UserId equals us.Id
                             select new CustomerDetailDto
                             {
                                 CompanyName = cu.CompanyName,
                                 FirstName = us.FirstName,
                                 LastName = us.LastName,

                             };
                return result.ToList();
            }
        }
    }
}
