using Core.Utilities.Results;
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
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetRentalById(int rentalId);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<RentalDetailDto>> GetRentalDetailsById(int rentalId);
        IDataResult<List<RentalDetailDto>> GetRentalDetailDetailsByCustomerId(int customerId);
        IDataResult<List<RentalDetailDto>> GetRentalDetailDetailsByBrandId(int brandId);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();

    }
}
