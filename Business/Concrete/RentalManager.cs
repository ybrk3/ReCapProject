using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalService)
        {
            _rentalDal = rentalService;
        }

        public IResult Add(Rental rental)
        {
            var result = _rentalDal.Get(r => r.Id == rental.Id && r.ReturnDate == null || r.RentDate > rental.RentDate);
            if (result == null)
            {
                return new ErrorResult();
            }

            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetRentalById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(b => b.BrandId == brandId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailDetailsByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(c => c.CustomerId == customerId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsById(int rentalId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.Id == rentalId));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            _rentalDal.GetRentalDetails();
            return new SuccessDataResult<List<RentalDetailDto>>();
        }
    }
}
