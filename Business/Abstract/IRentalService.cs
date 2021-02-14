using Core.Utilities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<Rental> GetRentalById(int id);
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental car);
        IResult Update(Rental car);
        IResult Delete(Rental car);
    }
}
