﻿//See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemoryCar;
using Entities.Concrete;
using System.Drawing;
using Business.Abstract;

//UserManager userManager = new UserManager(new EfUserDal());
//var users = userManager.GetAll();
//if (users.Success)
//{
//    foreach (var user in users.Data)
//    {
//        Console.WriteLine(user.FirstName);
//    }
//}
//else
//{
//    Console.WriteLine(users.Message);
//}

//CustomerTest();

//UserTest();


CarManager carManager = new CarManager(new EfCarDal());
Car car1 = new Car { Id = 1, BrandId = 1, ColorId = 1, CarName = "BMW 1.18", DailyPrice = 645, ModelYear = "2021", Description = "2.000 km'de, Joy plus paket. Aylık kiralamada kapmanya mevcuttur" };
carManager.Add(car1);





static void CustomerTest()
{
    CustomerManager customer = new CustomerManager(new EfCustomerDal());
    Customer customer1 = new Customer { Id = 1, UserId = 1, CompanyName = "Customer1 company" };
    Customer customer2 = new Customer { Id = 2, UserId = 2, CompanyName = "Customer2 company" };
    customer.Add(customer1);
    customer.Add(customer2);
    var result = customer.GetAll();
    if (result.Success)
    {
        foreach (var item in result.Data)
        {
            Console.WriteLine(item.CompanyName);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }

}

static void UserTest()
{
    UserManager userManager = new UserManager(new EfUserDal());
    User user1 = new User { Id = 1, FirstName = "B", LastName = "Y", Email = "yb", Password = "1234" };
    User user2 = new User { Id = 2, FirstName = "E", LastName = "D", Email = "ed", Password = "ed123" };
    userManager.Add(user1);
    userManager.Add(user2);
    var users = userManager.GetAll();
    if (users.Success)
    {
        foreach (var user in users.Data)
        {
            Console.WriteLine(user.FirstName);
        }
    }
    else
    {
        Console.WriteLine(users.Message);
    }
}