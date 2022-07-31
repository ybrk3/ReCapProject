// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemoryCar;

CarManager carManager = new CarManager(new RentalCarContext());




