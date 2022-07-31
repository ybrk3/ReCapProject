// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemoryCar;

CarManager car = new CarManager(new EfCarDal());
BrandManager brand = new BrandManager(new EfBrandDal());
ColorManager color = new ColorManager(new EfColorDal());


