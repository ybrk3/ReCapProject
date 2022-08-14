using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Color.Concrete;
using Color.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IResult Add(Color.Concrete.Color color)
        {
            _colorDal.Add(color);
           return new SuccessResult();
        }

        public IResult Delete(Color.Concrete.Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult();
        }

        public IDataResult<Color.Concrete.Color> GetById(int colorId)
        {
            var result = _colorDal.Get(co=> co.ColorId==colorId);
            if (result==null)
            {
                return new ErrorDataResult<Color.Concrete.Color>();
            }
            return new SuccessDataResult<Color.Concrete.Color>(result);
        }

        public IDataResult<List<Color.Concrete.Color>> GetAll()
        {
            if (DateTime.Now.Hour==1)
            {
                return new ErrorDataResult<List<Color.Concrete.Color>>(Messages.MaintenanceTime);
            } 
            return new SuccessDataResult<List<Color.Concrete.Color>>(_colorDal.GetAll());
        }


        public IResult Update(Color.Concrete.Color color)
        {
            _colorDal.Update(color);
           return new SuccessResult();
        }
    }
}
