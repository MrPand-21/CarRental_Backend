using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car entity)
        {
            if (entity.DailyPrice>0 && entity.Descriptio.Length>2)
            {
                _carDal.Add(entity);
            }
            
        }

        public void Delete(Car entity)
        {
            _carDal.Delete(entity);
        }

        public List<Car> GetAll()
        {
            //İŞ KODLARI BURADA YAPILACAK
            return _carDal.GetAll();
        }

        public Car GetById(int Id)
        {
            return _carDal.Get(c => c.CarId == Id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int Id)
        {
            return _carDal.GetAll(c => c.BrandId == Id);
        }

        public List<Car> GetCarsByColorId(int Id)
        {
            return _carDal.GetAll(c => c.ColorId == Id);
        }

        public void Update(Car entity)
        {
            _carDal.Update(entity);
        }
    }
}
