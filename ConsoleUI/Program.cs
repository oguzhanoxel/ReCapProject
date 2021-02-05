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
            CarManager carManager = new CarManager(new EfCarDal());
            List<Car> _cars = carManager.GetAll();

            void MyList(string listTitle) {
                Console.WriteLine("\n\n" + listTitle.ToUpper());
                foreach (var item in carManager.GetAll())
                {
                    Console.WriteLine(
                        "\n" +
                        "id = " + item.Id + "\n" +
                        "brand id = " + item.BrandId + "\n" +
                        "color id = " + item.ColorId + "\n" +
                        "name = " + item.Name + "\n" +
                        "model year = " + item.ModelYear + "\n" +
                        "daily price = " + item.DailyPrice + "\n" +
                        "desc = " + item.Description
                    );
                }
            }

            MyList("Cars"); // İlk liste

   
        }
    }
}
