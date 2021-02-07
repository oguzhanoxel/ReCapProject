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
            CarTest();
        }

        
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetCarDetails())
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
        
    }
}
