// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete;

CarManager carManager = new CarManager(new InMemoryCar());
foreach (var car in carManager.GetById(2))
{
    Console.WriteLine(car.Description);
}


