using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Utilities.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        public IResult Add(IFormFile file ,CarImage carImage);
        public IResult Update(CarImage carImage);
        public IResult Delete(CarImage carImage);
        public IDataResult<List<CarImage>> GetAll();
        public IDataResult<CarImage> GetById(int id);

    }
}
