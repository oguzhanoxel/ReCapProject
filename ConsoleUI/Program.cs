using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //TestArea();
            UserTest();
        }

        
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            foreach (var item in result.Data)
            {
                Console.WriteLine(
                    "\n" +
                    "CarName= " + item.CarName + "\n" +
                    "BrandName= " + item.BrandName + "\n" +
                    "ColorName= " + item.ColorName + "\n" +
                    "DailyPrice= " + item.DailyPrice
                );
            }
        }
        private static void UserTest()
        {
            UserManager userManeger = new UserManager(new EfUserDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.GetAll();

            foreach (var item in result.Data)
            {
                Console.WriteLine(
                    "\n" +
                    "FirstName= " + item.ID + "\n" +
                    "LastName= " + item.Name + "\n" +
                    "Email= " + item.Name
                );
            }
        }

        private static void TestArea()
        {
            UserManager userManeger = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            User user = userManeger.GetById(6).Data;

            User newUser = new User();
            newUser.FirstName = "Mustafa";
            newUser.LastName = "K.";
            newUser.Email = "mustafa@example.com";
            newUser.Password = "123456789Qq";

            Customer newCustomer = new Customer();
            newCustomer.UserID = 7;
            newCustomer.CompanyName = "F company";

            Rental newRental = new Rental();
            newRental.CarID = 5;
            newRental.CustomerID = 6;
            newRental.RentDate = new DateTime(2021, 01, 12, 12, 00, 00);

            //var result = rentalManager.Add(newRental);
            //var result = customerManager.Add(newCustomer);
            //var result = userManeger.Add(newUser);
            //var result = userManeger.Delete(user);
            //Console.WriteLine(result.Message);

        }

    }
}
