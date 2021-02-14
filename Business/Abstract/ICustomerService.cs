using Core.Utilities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<Customer> GetCustomerById(int id);
        IDataResult<List<Customer>> GetAll();
        IResult Add(Customer car);
        IResult Update(Customer car);
        IResult Delete(Customer car);
    }
}
