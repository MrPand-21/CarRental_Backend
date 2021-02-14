using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carmanager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand2 = new Brand
            {
                BrandId = 2,
                Name = "Brand2"
            };
            Color color1 = new Color { Name = "Color2", Colorid = 1 };
            Car  car1 = new Car { BrandId = 2, ColorId = 1, DailyPrice = 1221, Descriptio = "ssw", CarId = 1, ModelYear = 1122 };


            //brandManager.Add(brand2);
            //colorManager.Add(color1);
            //carmanager.Add(car1);
            //carmanager.Delete(car1);
            foreach (var car in carmanager.GetCarDetails())
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine("sasasas");


        }
    }
}
