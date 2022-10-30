using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFileCollection formFiles, int id);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetCarImageById(int id);
        IResult Update(IFormFile file, CarImage carImage);
        IResult Delete(CarImage carImage);

    }
}
