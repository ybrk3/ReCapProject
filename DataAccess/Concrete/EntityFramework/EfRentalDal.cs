using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentalCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var result = from r in context.Rentals
                             join b in context.Brands on r.BrandId equals b.BrandId
                             join c in context.Customers on r.CustomerId equals c.Id
                             join u in context.Users on c.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 BrandName = b.BrandName,
                                 CustomerName = u.FirstName + ' ' + u.LastName,
                                 ReturnDate = Convert.ToDateTime(r.ReturnDate),
                                 RentDate = Convert.ToDateTime(r.RentDate),
                             };
                return result.ToList();
            }
        }
    }
}
