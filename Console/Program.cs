using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carmanager = new CarManager(new InMemoryCarDal());

            foreach (var car in carmanager.GetAll())
            {
                Console.WriteLine(car.Id);
                Console.WriteLine(car.DailyPrice);
            }

            Console.WriteLine(carmanager.GetById(2).DailyPrice);
        }
    }
}
