using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarCheck();

            RentalCheck();
        }

        private static void RentalCheck()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Rental rental = new Rental { CarId = 1, CustomerId = 2, RentDate = new DateTime(2022, 09, 16), ReturnDate = null };

            var result = rentalManager.Add(rental);
            Console.WriteLine(result.Message);
            Console.WriteLine(result.Success);
        }

        private static void CarCheck()
        {
            CarManager carmanager = new CarManager(new EfCarDal());

            var result = carmanager.GetCarsByColorId(10);

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Name);
                }
            }

            Console.WriteLine(result.Message);
        }
    }
}
