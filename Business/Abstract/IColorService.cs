using Core.Utilities;
using Color.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color.Concrete.Color>> GetAll();
        IDataResult<Color.Concrete.Color> GetById(int colorId);
        IResult Add(Color.Concrete.Color color);
        IResult Update(Color.Concrete.Color color);
        IResult Delete(Color.Concrete.Color color);

    }
}
