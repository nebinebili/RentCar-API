using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carmanager = new CarManager(new EfCarDal());

            foreach (var car in carmanager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.ModelYear);
            }
        }
    }
}
