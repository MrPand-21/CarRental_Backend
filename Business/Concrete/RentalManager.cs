using Business.Abstract;
using Core.Utilities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        public IResult Add(Rental car)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Rental car)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Rental> GetRentalById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental car)
        {
            throw new NotImplementedException();
        }
    }
}
