using Business.Concrete;
using DataAccess.Concrete.InMemory;
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
            CarManager carManager = new CarManager(new InMemoryCarDal());
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
                        "model year = " + item.ModelYear.Year + "\n" +
                        "daily price = " + item.DailyPrice + "\n" +
                        "desc = " + item.Description
                    );
                }
            }

            MyList("First List"); // İlk liste

            Car newCar = new Car();
            newCar.Id = 6;
            newCar.BrandId = 1;
            newCar.ColorId = 2;
            newCar.ModelYear = new DateTime(2013);
            newCar.DailyPrice = 700;
            newCar.Description = "Description5";
            
            carManager.Add(newCar);

            MyList("Added car, Car ID = " + newCar.Id); // yeni araba eklendikden sonra

            Car carToDelete = _cars.SingleOrDefault(p => p.Id == 3); // kullanıcıdan id si 3 olan arabayı geldiği varsayılı
            carManager.Delete(carToDelete);

            MyList("Deleted car, Car ID = " + carToDelete.Id); // id si 3 olan arabanin silindiği liste

            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == 2); // kullanıcı veya adminin id si 2 olan arabayi güncellediği varsayılı
            carToUpdate.Description = "Updated Description";
            carToUpdate.DailyPrice = 799;

            MyList("Updated Car, Car ID = " + carToUpdate.Id); // id si 2 olan arabanin güncellendiği liste

        }
    }
}
