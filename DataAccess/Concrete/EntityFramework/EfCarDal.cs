using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car,CarRentalContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context=new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join o in context.Colors 
                             on c.ColorId equals o.Colorid
                             select new CarDetailDto { BrandName = b.Name, CarName = c.Descriptio, ColorName = o.Name };
                return result.ToList();
            }
        }
    }
}
