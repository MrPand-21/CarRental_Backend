using Business.Abstract;
using Core.Utilities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        public IResult Add(Customer car)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Customer car)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Customer> GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Customer car)
        {
            throw new NotImplementedException();
        }
    }
}
