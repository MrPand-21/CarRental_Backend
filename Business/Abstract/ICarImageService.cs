using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Utilities.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        public IResult Add(CarImage carImage);
        public IResult Update(CarImage carImage);
        public IResult Delete(CarImage carImage);
        public IDataResult<List<CarImage>> GetAll();
        public IDataResult<CarImage> GetById(int id);

    }
}
